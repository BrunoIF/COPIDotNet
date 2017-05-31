create table tb_AC_cliente_02(
cpf varchar(11) primary key,
nome varchar(50) not null,
email nvarchar(100) not null,
telefone varchar(15) not null,
cep varchar(8) not null,
logradouro varchar(50) not null,
complemento int not null,
bairro varchar(50) not null,
uf varchar(2) not null
)

drop table tb_AC_cliente_02