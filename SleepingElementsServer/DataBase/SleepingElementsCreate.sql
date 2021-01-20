Create database SleepingElements;

use SleepingElements;



create table User(Username varchar(32) not null,
                  Password varchar(32) not null,
                  User_ID int not null auto_increment,
                  Pet_ID int,
                  primary key(User_ID));
         
create table Pets(Petname varchar(32) not null,
				  Pet_ID int not null auto_increment,
                  PetEffectval int,
                  primary key(Pet_ID));


# foreign keys

alter table User add 
	foreign key (Pet_ID) references Pets (Pet_ID);
                  