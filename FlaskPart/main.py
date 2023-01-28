from flask import Flask, request, make_response, jsonify
import CoordinatesUtils
import  gateway

app = Flask(__name__)


@app.route("/")
def hello_world():
    return "<p>Shadow Buildings</p>"


@app.route("/GetGeoInfo", methods=['POST', 'GET'])
def get_geo_info():
    x = float(request.args.get('x'))
    y = float(request.args.get('y'))
    bbox = CoordinatesUtils.get_projected_bbox_from_coordinates(x, y)
    response = gateway.get_cadastre_info_from_open_data_base(bbox)
    return make_response(response)


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000, debug=True)