INSERT INTO action_event(etype)
VALUES ('watering_start'),
       ('watering_end'),
       ('watering_continue'),
       ('human_detected');

INSERT INTO weather_data(temperature, humidity, water_saved)
VALUES (2.5, 4, 5),
        (3.5, 6, 5);
