
CREATE TABLE UserInfo
(
	Id int primary key IDENTITY(1,1),
	Email nvarchar(50) not null,
	Password nvarchar(50) not null
)

CREATE TABLE UserSettings
(
	Id int primary key IDENTITY(1,1),
	EnableAutoStart bit default '0' not null,
	UseEatingTimer bit default '0' not null,
	UseEyesTimer bit default '0' not null,
	UseExerciseTimer bit default '0' not null,
	UseShutDownTimer bit default '0' not null,
	EatingTimer int,
	EyesTimer int,
	ExerciseTimer int,
	ShutDownTimer int,
	UserId int foreign key references UserInfo(Id)
)

CREATE TABLE UserHistory
(
	Id int primary key IDENTITY(1,1),
	UserId int foreign key references UserInfo(Id),
	Date nvarchar(20) not null,
	WorkingTime int not null
)