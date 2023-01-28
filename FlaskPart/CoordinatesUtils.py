from osgeo import ogr
from osgeo import osr
import math


def get_EPSG(pointX, pointY):
    # Spatial Reference System
    inputEPSG = 4326
    outputEPSG = 3857

    # create a geometry from coordinates
    point = ogr.Geometry(ogr.wkbPoint)
    point.AddPoint(pointX, pointY)

    # create coordinate transformation
    inSpatialRef = osr.SpatialReference()
    inSpatialRef.ImportFromEPSG(inputEPSG)

    outSpatialRef = osr.SpatialReference()
    outSpatialRef.ImportFromEPSG(outputEPSG)

    coordTransform = osr.CoordinateTransformation(inSpatialRef, outSpatialRef)

    # transform point
    point.Transform(coordTransform)

    # print point in EPSG 4326
    # print (point.GetX(), point.GetY(),sep=',')
    return (point.GetX(), point.GetY())

class BoundingBox(object):
    def __init__(self, *args, **kwargs):
        self.lat_min = None
        self.lon_min = None
        self.lat_max = None
        self.lon_max = None


def get_bounding_box(latitude_in_degrees, longitude_in_degrees, half_side_in_miles=0.01):
    assert half_side_in_miles > 0
    assert latitude_in_degrees >= -90.0 and latitude_in_degrees  <= 90.0
    assert longitude_in_degrees >= -180.0 and longitude_in_degrees <= 180.0

    half_side_in_km = half_side_in_miles * 1.609344
    lat = math.radians(latitude_in_degrees)
    lon = math.radians(longitude_in_degrees)

    radius  = 6371
    # Radius of the parallel at given latitude
    parallel_radius = radius*math.cos(lat)

    lat_min = lat - half_side_in_km/radius
    lat_max = lat + half_side_in_km/radius
    lon_min = lon - half_side_in_km/parallel_radius
    lon_max = lon + half_side_in_km/parallel_radius
    rad2deg = math.degrees

    box = BoundingBox()
    box.lat_min = rad2deg(lat_min)
    box.lon_min = rad2deg(lon_min)
    box.lat_max = rad2deg(lat_max)
    box.lon_max = rad2deg(lon_max)

    #print(box.lat_min,box.lon_min,box.lat_max,box.lon_max, sep=',')
    return (box.lat_min,box.lon_min,box.lat_max,box.lon_max)


def get_projected_bbox(bbox):
    first = get_EPSG(bbox[0], bbox[1])
    second = get_EPSG(bbox[2], bbox[3])
    res = (first[0], first[1], second[0], second[1])
    return res


def get_projected_bbox_from_coordinates(latitude_in_degrees, longitude_in_degrees):
    bbox = get_bounding_box(latitude_in_degrees, longitude_in_degrees, half_side_in_miles=0.01)
    return get_projected_bbox(bbox)