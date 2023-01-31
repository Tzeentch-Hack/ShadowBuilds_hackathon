# ShadowBuilds_hackathon
Programm for checking detected buildings in cadastre data base


# Описание:
ShadowBuilds - это клиент-серверное приложение, основная задача которого - проверять наличие записи о постройке в кадастровом реестре Узбекистана https://davreestr.kadastr.uz. 
Программа сканирует спутниковый снимок выбранной на карте области, обнаруживает и выделяет постройки. По найденным координатам построек запрашивается информация с кадастрового реестра.
Если информация в реестре отсутствует - следует проверить законность постройки или актуализировать кадастровый реестр. 

Программа была написана в рамках хакатона Open Data Challenge https://datahack.uz/ 27-29 января. По итогам оценок со стороны жюри проекту было присуждено 1-е место.

# Детали реализации:

Программа разделена на 2 части:
1) Пользовательский клиент реализован с использованием движка реального времени Unity на языке C#.
2) Рабочая логика реализована с использованием фреймворка Flask на языке Python.

Информация о кадастре берётся с сайта http://map.geoportal.uz/. Запросы прописаны в файле gateway.py. 
Поиск информации в реестре осуществляется в пределах запрашиваемого прямоугольника.
Код, приводящий координаты в формат EPSG 3857 (с которым работает сайт) и выдающий небольшую область по указанной точке содержится в файле CoordinatesUtils.py.
Для работы подпрограммы перевода координат необходимо установить GDAL (установочный файл для Python 3.10 находится в папке requirements в этом репозитории.
Для детектирования и сегментации зданий используется YoloV8 и спутниковые снимки от Yandex.
Провайдером схематической карты и геокодинга так же является Yandex.
Адрес сервера на клиенте прописан в файле /UnityPart/ShadowBuildsUnity/Assets/Scripts/Gateway/GeoPosGateWay.cs

# Установка:
1) Клонировать репозиторий.
2) Создать виртуальную среду Python (если нужно) 
3) Установить GDAL. На Windows это можно сделать с помощью команды 
pip install '.../GDAL-3.4.3-pp38-pypy38_pp73-win_amd64.whl', где '.../GDAL-3.4.3-pp38-pypy38_pp73-win_amd64.whl' путь к установочному файлу.
4) Установить Flask. 
pip install flask
5) Запустить сервер 
python main.py
5) Собрать проект Unity или запустить его в редакторе. Не забудьте изменить адрес сервера на акутальный в файле .../UnityPart/ShadowBuildsUnity/Assets/Scripts/Gateway/GeoPosGateWay.cs. Или - можно обратиться к серверу через браузер/Postman и т.п.

# Description:
ShadowBuilds is a client-server application, the main task of which is to check the construction record in the cadastral register of Uzbekistan https://davreestr.kadastr.uz.
The program scans a satellite image of the area selected on the map, detects and highlights buildings. According to the found coordinates of buildings, information is requested from the cadastral register.
If there is no information in the register, needs to check the legality of the construction or update the cadastral register.

The program was written as part of the Open Data Challenge hackathon https://datahack.uz/ January 27-29. Based on the results of the jury's assessments, the project was awarded 1st place.

# Implementation Details:

The program is divided into 2 parts:
1) The user client is implemented using the Unity real-time engine in C#.
2) The working logic is implemented using the Flask framework in Python.

Information about the cadastre is taken from the website http://map .geoportal.uz/. Requests are coded in the file gateway.py .
The information in the registry is searched within the requested rectangle.
The code that converts the coordinates to the EPSG 3857 format (with which the site works) and gives out a small area at the specified point is contained in the file CoordinatesUtils.py.
For the coordinate translation routine to work, you need to install GDAL (the installation file for Python 3.10 is located in the requirements folder in this repository.
YoloV8 and satellite images from Yandex are used for detecting and segmenting buildings.
The provider of the schematic map and geocoding is also Yandex.
The server address on the client is registered in the file /UnityPart/ShadowBuildsUnity/Assets/Scripts/Gateway/GeoPosGateWay.cs.

# Installation:
1) Clone the repository.
2) Create a Python virtual environment (if necessary)
3) Install GDAL. On Windows, this can be done using
the pip install command '.../GDAL-3.4.3-pp38-pypy38_pp73-win_amd64.whl', where '.../GDAL-3.4.3-pp38-pypy38_pp73-win_amd64.whl' is the path to the installation file.
4) Install Flask.
pip install flask
5) Start the server 
python main.py
5) Build a Unity project or run it in the editor. Don't forget to change the server address to the actual one in the file .../UnityPart/ShadowBuildsUnity/Assets/Scripts/Gateway/GeoPosGateWay.cs. Or - you can access the server via the browser/Postman, etc.


