CREATE TABLE teos(
id tinyint unsigned not null auto_increment,
id_o tinyint unsigned not null,
id_t tinyint unsigned not null,
primary key (id),
foreign key (id_o) references osoby(id_o),
foreign key (id_t) references telefony(id_t)
)
engine = innoDB default character set utf8 
collate utf8_unicode_ci;

