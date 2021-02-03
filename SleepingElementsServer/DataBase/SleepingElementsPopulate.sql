-- information

use sleeping_elements;

insert into User (Username, Password) values ('Leon', 'Leon');
insert into User (Username, Password) values ('test', 'test');

insert into Pets (petName, petHealthProgress, petHappinessProgress, petHungerProgress, petHygieneProgress, petEffectVal, user_ID) values ("Leonidas", 50, 50, 50, 50, 2, 1);
insert into Pets (petName, petHealthProgress, petHappinessProgress, petHungerProgress, petHygieneProgress, petEffectVal, user_ID) values ("Pendragon", 100, 100, 100, 100, 2, 1);



#insert into Pets (Petname, PetEffectval, User_ID, ) values ('Leonidas', '2', '1', '100');
#insert into Pets (Petname, PetEffectval, User_ID, ) values ('testo', '1', '2', '50');
#insert into Pets (Petname, PetEffectval, User_ID, ) values ('Rey', '2', '1', '10');

select * from pets;
drop table pets
                  