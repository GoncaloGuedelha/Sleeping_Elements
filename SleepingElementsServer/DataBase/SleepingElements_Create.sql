Create database Sleeping_Elements;

use Sleeping_Elements;



create table User(Username varchar(32) not null,
                  Password varchar(32) not null,
                  User_ID int not null auto_increment,
                  primary key(User_ID));
         
create table Pets(Petname varchar(32) not null,
				  pet_ID int not null auto_increment,
                  user_ID int not null,
                  petHealthProgress int not null,
                  petHappinessProgress int not null,
                  petHungerProgress int not null,
                  petHygieneProgress int not null,
                  petEffectVal int,
                  primary key(Pet_ID));


# foreign keys

alter table Pets add 
	foreign key (User_ID) references User (User_ID);
                  