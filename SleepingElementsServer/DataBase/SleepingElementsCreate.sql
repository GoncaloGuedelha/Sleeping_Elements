Create database SleepingElements;

use SleepingElements;



create table User(Username varchar(32) not null,
                  Password varchar(32) not null,
                  User_ID int not null auto_increment,
                  primary key(User_ID));
         
create table Pets(Petname varchar(32) not null,
				  Pet_ID int not null auto_increment,
                  User_ID int not null,
                  PetHealthBar int not null,
                  PetEffectval int,
                  primary key(Pet_ID));


# foreign keys

alter table Pets add 
	foreign key (User_ID) references User (User_ID);
                  