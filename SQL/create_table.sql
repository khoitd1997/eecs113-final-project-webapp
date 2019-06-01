DROP TABLE IF EXISTS action_event;
DROP TYPE IF EXISTS event_type;
CREATE TYPE event_type AS ENUM ('watering_start', 'watering_end', 'watering_continue', 'human_detected');
CREATE TABLE action_event
(
    eid        SERIAL PRIMARY KEY,
    etype      event_type               NOT NULL,
    time_stamp TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW()
);

DROP TABLE IF EXISTS weather_data;
CREATE TABLE weather_data
(
    wid         SERIAL PRIMARY KEY,
    temperature float                    NOT NULL,
    humidity    float                    NOT NULL,
    water_saved float                    NOT NULL,
    time_stamp TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW()
);