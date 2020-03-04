CREATE TABLE telefony(
id_t tinyint unsigned not null auto_increment,
numer char(9) not null,
typ enum("stacjonarny","komorkowy") not null default "komorkowy",
operator enum("era","play","heyah","tp") not null,
primary key (id_t)
)
engine = innoDB default character set utf8 
collate utf8_unicode_ci;

