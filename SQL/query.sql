SELECT A.eid, A.etype, A.time_stamp
FROM action_event A
ORDER BY A.time_stamp DESC
LIMIT 5;

SELECT W.wid, W.temperature, W.humidity, W.water_saved, W.time_stamp
FROM weather_data W
ORDER BY W.time_stamp DESC
LIMIT 5;
