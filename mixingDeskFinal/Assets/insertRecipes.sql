INSERT INTO recipes(name, creatorName, notes, postDate, rating, flav_1Percent, flav_2Percent, flav_3Percent, flav_4Percent, flav_5Percent, flav_6Percent, flav_7Percent,
flav_1_FK, flav_2_FK, flav_3_FK, flav_4_FK, flav_5_FK, flav_6_FK, flav_7_FK) VALUES ('Mother''s Unicorn Milk', 'apwroblewski',NULL, (SELECT datetime('now','-1 month'))/*do dates later*/, /*rating*/3.0, 4.0, 5.0, 10.00, 4.00, 3.00, NULL, NULL,
(SELECT idNumbF FROM flavourings WHERE name='Bavarian Cream (TPA)'), 
(SELECT idNumbF FROM flavourings WHERE name='Cheesecake (Graham Crust) (TPA)'),
(SELECT idNumbF FROM flavourings WHERE name='Strawberry (Ripe) (TPA)'),
(SELECT idNumbF FROM flavourings WHERE name='Sweet Cream (TPA)'),
(SELECT idNumbF FROM flavourings WHERE name='Vanilla Custard (TPA)'),
NULL, NULL
);
INSERT INTO recipes(name, creatorName, notes, postDate, rating, flav_1Percent, flav_2Percent, flav_3Percent, flav_4Percent, flav_5Percent, flav_6Percent, flav_7Percent,
flav_1_FK, flav_2_FK, flav_3_FK, flav_4_FK, flav_5_FK, flav_6_FK, flav_7_FK) VALUES ('Kreed''s Kustard', 'Kevin Reed',NULL, (SELECT datetime('now','-6 month'))/*do dates later*/, /*rating*/1.0, 
1.0, 4.50, 4.50, 6.0, NULL, NULL, NULL,
(SELECT idNumbF FROM flavourings WHERE name='Cotton Candy (10% Ethyl Maltol) (TPA)'), 
(SELECT idNumbF FROM flavourings WHERE name='French Vanilla (CAP)'),
(SELECT idNumbF FROM flavourings WHERE name='New York Cheesecake (CAP)'),
(SELECT idNumbF FROM flavourings WHERE name='Vanilla Custard (CAP)'),
NULL,
NULL, NULL
);

INSERT INTO recipes(name, creatorName, notes, postDate, rating, flav_1Percent, flav_2Percent, flav_3Percent, flav_4Percent, flav_5Percent, flav_6Percent, flav_7Percent,
flav_1_FK, flav_2_FK, flav_3_FK, flav_4_FK, flav_5_FK, flav_6_FK, flav_7_FK) VALUES ('Frosted Flakes', 'Shroomalistic','This is spot on frosted flakes. All I did was shake and vape and it''s exact. Give it a shot and tell me if I''m off.',
(SELECT datetime('now','-7 day')), /*rating*/2.0, 
1.0, 1.0, 1.0, 1.0, 2.0, 1.0, 2.0,
(SELECT idNumbF FROM flavourings WHERE name='Acetyl Pyrazine 5% (TPA)'), 
(SELECT idNumbF FROM flavourings WHERE name='Cream Fresh (FA)'),
(SELECT idNumbF FROM flavourings WHERE name='Hazelnut (FW)'),
(SELECT idNumbF FROM flavourings WHERE name='Marshmallow (FA)'),
(SELECT idNumbF FROM flavourings WHERE name='Meringue (FA)'),
(SELECT idNumbF FROM flavourings WHERE name='Super Sweet (CAP)'),
(SELECT idNumbF FROM flavourings WHERE name='Cake (Yellow) (FW)')
);

INSERT INTO recipes(name, creatorName, notes, postDate, rating, flav_1Percent, flav_2Percent, flav_3Percent, flav_4Percent, flav_5Percent, flav_6Percent, flav_7Percent,
flav_1_FK, flav_2_FK, flav_3_FK, flav_4_FK, flav_5_FK, flav_6_FK, flav_7_FK) VALUES ('Sinnamon Cookie Kustard', 'Ken O''Where','This is not entirely original, it is a play off of an old recipe called Snickerdoodle, i no longer remember where i found it as it was a couple years ago. I have altered the %''s because custard! In the original the CDS was a bit overpowering. 
I suggest a two week cure in a cold dark place. I rate my recipes to let others know how much i like it, this is in my ADV rotation and i vape it daily.',
(SELECT datetime('now','-1 day')), /*rating*/0.5, 
4.0, 7.0, 4.5, NULL, NULL, NULL, NULL,
(SELECT idNumbF FROM flavourings WHERE name='Cinnamon Danish Swirl (CAP)'), 
(SELECT idNumbF FROM flavourings WHERE name='Sugar Cookie (CAP)'),
(SELECT idNumbF FROM flavourings WHERE name='Vanilla Custard (CAP)'),
NULL,
NULL,
NULL,
NULL
);


INSERT INTO recipes(name, creatorName, notes, postDate, rating, flav_1Percent, flav_2Percent, flav_3Percent, flav_4Percent, flav_5Percent, flav_6Percent, flav_7Percent,
flav_1_FK, flav_2_FK, flav_3_FK, flav_4_FK, flav_5_FK, flav_6_FK, flav_7_FK) VALUES ('MY DUDE (My Man Remix)', 'ENYAWREKLAW','MIX AT: 75VG///25PG
STEEP: AT LEAST 3 DAYS (Best After 1 Week)

(Optional) TFA Double Chocolate Clear - 3%

Some state they can taste a touch of chocolate in this recipe. I as well as my partners do not taste any. So I wouldn''t add any in but if you think there is some chocolate then I added an optional ingredient that will give you that slight chocolate taste. This is not part of my recipe though, so mix at your own discretion.

"A SUGARY AND SWEET NEAPOLITAN ICE CREAM (KINDA)."




(This recipe is the creation of [ENYAWREKLAW]. If you find any recipes claiming they are from [ENYAWREKLAW] not posted under this account and are unsure of its authenticity, please head to diyordievaping.com where you will find all of the creators orginal recipes)',
(SELECT datetime('now')), 4.0, 
0.5, 1.0, 3.0, 1.0, 4.0, 2.0, 4.0,
(SELECT idNumbF FROM flavourings WHERE name='Cream Fresh (FA)'), 
(SELECT idNumbF FROM flavourings WHERE name='Marshmallow (TPA)'),
(SELECT idNumbF FROM flavourings WHERE name='Strawberry (TPA)'),
(SELECT idNumbF FROM flavourings WHERE name='Sweet Cream (TPA)'),
(SELECT idNumbF FROM flavourings WHERE name='Sweet Strawberry (CAP)'),
(SELECT idNumbF FROM flavourings WHERE name='Sweetener (Sucralose/Maltol) (TPA)'),
(SELECT idNumbF FROM flavourings WHERE name='Vanilla Bean Ice Cream (TPA)')
);

