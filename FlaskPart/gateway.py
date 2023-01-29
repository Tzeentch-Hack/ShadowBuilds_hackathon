import requests
from PIL import Image
from io import StringIO
def get_satellite_image_by_bbox(bobox):
    payload = {'l': 'sat', 'bbox': '{},{}~{},{}'.format(bobox[0], bobox[1], bobox[2], bobox[3]), 'size':'450,450'}
    r = requests.get('https://static-maps.yandex.ru/1.x/', params=payload)
    print('r.url', r.url)
    with open("response.jpg", "wb") as f:
        f.write(r.content)
    return "response.jpg"

def get_satellite_image_by_centre_and_zoom(centre, zoom):
    payload = {'l': 'sat', 'll': '{},{}'.format(centre[0], centre[1]), 'size': '450,450', 'z': zoom}
    r = requests.get('https://static-maps.yandex.ru/1.x/', params=payload)
    print('r.url', r.url)
    with open("response.jpg", "wb") as f:
        f.write(r.content)
    return "response.jpg"


def get_cadastre_info_from_open_data_base(bbox):
    payload = {'service': 'WMS', 'version': '1.1.1', 'request': 'GetFeatureInfo',
               'exceptions': 'application/json', 'id': 'farhod:dkyat__8', 'layers': 'farhod:dkyat',
               'query_layers': 'farhod:dkyat', 'x': '51', 'y': '51', 'height': '101', 'width': '101',
               'srs': 'EPSG:3857', 'bbox': '{},{},{},{}'.format(bbox[0], bbox[1], bbox[2], bbox[3]),
               'feature_count': '10', 'info_format': 'application/json', 'ENV': 'mapstore_language:en'}
    #print(payload)
    r = requests.get('http://giscad.uz:8164/baza/gwc/service/wms', params=payload)
    return r.json()

