from flask import Flask, request, make_response, jsonify
import CoordinatesUtils
import gateway
from PIL import Image
from io import StringIO
import detection
import json

app = Flask(__name__)


def check_in_cadastre(x: float, y: float) -> bool:
    bbox = CoordinatesUtils.get_projected_bbox_from_coordinates(x, y)
    response = gateway.get_cadastre_info_from_open_data_base(bbox)
    print('response:', response)
    if len(response['features']) == 0:
        return False
    else:
        return True


@app.route("/")
def hello_world():
    return "<p>Shadow Buildings</p>"


@app.route("/GetGeoInfo", methods=['POST', 'GET'])
def get_geo_info():
    try:
        x = float(request.args.get('x'))
        y = float(request.args.get('y'))
        print("Get geoInfo request for x = " + str(x) + ", y=" + str(y))
        bbox = CoordinatesUtils.get_projected_bbox_from_coordinates(x, y)
        response = gateway.get_cadastre_info_from_open_data_base(bbox)
        print("response with ", response)
        return make_response(response)
    except Exception as e:
        return make_response(str(e))


@app.route("/PostCadastreMapInfo", methods=['POST'])
def post_cadastre_map_info():
    data = request.get_json()
    # image_path = gateway.get_satellite_image_by_bbox((data['blX'], data['blY'], data['trX'], data['trY']))
    print(data)
    image_path = gateway.get_satellite_image_by_centre_and_zoom((float(data['x']), float(data['y'])), data['z'])
    bbox_centers = detection.infer_image(image_path, (450, 450), (
        float(data['blX']), float(data['trY']), float(data['trX']), float(data['blY'])))
    cadastre_bbox_centers = []
    for dct in bbox_centers:
        if not check_in_cadastre(dct['y'], dct['x']):
            cadastre_bbox_centers.append(dct)
    res = {
        'points': cadastre_bbox_centers
    }
    return make_response(jsonify(res))


@app.route("/PostCurrentMapInfo", methods=['POST'])
def post_current_map_info():
    data = request.get_json()
    # image_path = gateway.get_satellite_image_by_bbox((data['blX'], data['blY'], data['trX'], data['trY']))
    print(data)
    image_path = gateway.get_satellite_image_by_centre_and_zoom((float(data['x']), float(data['y'])), data['z'])
    bbox_centers = detection.infer_image(image_path, (450, 450), (
        float(data['blX']), float(data['trY']), float(data['trX']), float(data['blY'])))
    # cadastre_bbox_centers = []
    # for x, y in bbox_centers:
    #     if check_in_cadastre(x, y):
    #         cadastre_bbox_centers.append((x,y))
    res = {
        'points': bbox_centers
    }
    return make_response(jsonify(res))


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000, debug=True)
