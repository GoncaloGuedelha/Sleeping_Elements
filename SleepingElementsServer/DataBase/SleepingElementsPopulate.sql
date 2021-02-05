-- information

use sleeping_elements;

insert into User (Username, Password) values ('Leon', 'Leon');
insert into User (Username, Password) values ('test', 'test');

insert into Pets (petName, petHealthProgress, petHappinessProgress, petHungerProgress, petHygieneProgress, petEffectVal, user_ID) values ("Leonidas", 50, 50, 50, 50, 2, 1);
insert into Pets (petName, petHealthProgress, petHappinessProgress, petHungerProgress, petHygieneProgress, petEffectVal, user_ID) values ("Pendragon", 100, 100, 100, 100, 2, 1);


select * from pets;
				