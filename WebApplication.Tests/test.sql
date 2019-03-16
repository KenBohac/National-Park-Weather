-- Delete all of the data
DELETE FROM survey_result;

DELETE FROM weather;
DELETE FROM park;

-- Insert a fake park
INSERT INTO park VALUES ('AAAA', 'Test Park', 'AK', 100, 0, 100, 1, 'Desert', 2019, 0, 'I like tests', 'Ms. Test', 'BLAH', 1, 1);

-- Insert a fake weather
INSERT INTO weather VALUES ('AAAA', 1, 0, 0, 'rain');
INSERT INTO weather VALUES ('AAAA', 2, 0, 0, 'rain');
INSERT INTO weather VALUES ('AAAA', 3, 0, 0, 'rain');
INSERT INTO weather VALUES ('AAAA', 4, 0, 0, 'rain');
INSERT INTO weather VALUES ('AAAA', 5, 0, 0, 'rain');


-- Insert a fake survey
INSERT INTO survey_result VALUES ('AAAA', 'myemail@gmail.com', 'Ohio','sedentary');


