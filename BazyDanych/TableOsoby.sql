CREATE TABLE osoby(
id_o tinyint unsigned not null auto_increment,
imie varchar(20) not null,
nazwisko varchar(30) not null,
miasto varchar(30) default "Gliwice",
primary key (id_o)
)
engine = innoDB default character set utf8 
collate utf8_unicode_ci;
