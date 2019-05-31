SELECT *
FROM action_event A
ORDER BY A.start_time DESC
LIMIT 5;

SELECT *
FROM weather_data W
ORDER BY W.record_time DESC
LIMIT 1;
