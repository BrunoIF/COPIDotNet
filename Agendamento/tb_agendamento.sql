create table tb_agendamento_02(
	id int primary key identity(1,1),
	h1 varchar(50),
	h2 varchar(50),
	h3 varchar(50),
	h4 varchar(50),
	h5 varchar(50),
	agendamento varchar(50)
);
-- Criar outros campos h6. h7, h8, h9... para outros horários de agendamento

select * from tb_agendamento_02