SELECT * FROM Servicos
INNER JOIN Clientes ON Clientes.Id = ClienteId
WHERE Nome = 'Nicolas'; 

SELECT * FROM Clientes 

SELECT * FROM Servicos 

INSERT INTO Servicos (ClienteId, Valor, Categoria, Data, Descricao)
SELECT Id, 90.00, 0, '2023-10-26', 'teste do serviço'
FROM Clientes
WHERE Nome = 'NICOLAS' AND QuadraELote='A10LOTE40'

SELECT Nome,QuadraELote FROM Clientes
INNER JOIN Servicos on ClienteId=Clientes.Id


SELECT Valor From Servicos
INNER JOIN Clientes ON Clientes.Id = ClienteId 
WHERE Nome = 'Nicolas'; 

SELECT * 
FROM Clientes 
INNER JOIN Servicos ON Clientes.Id = Servicos.ClienteId 
WHERE Servicos.Data = '2023-10-26'

SELECT Servicos.Categoria, Servicos.Data, Servicos.Descricao
FROM Clientes
INNER JOIN Servicos ON Clientes.Id = Servicos.ClienteId
WHERE Servicos.Data = '2023-10-26';


SELECT Clientes.Id, Clientes.Nome, Servicos.Categoria, Servicos.Data, Servicos.Descricao, Servicos.Valor
FROM Clientes
INNER JOIN Servicos ON Clientes.Id = Servicos.ClienteId
WHERE Servicos.Data = '2023-10-26'; 

SELECT Servicos.Data, SUM(Servicos.Valor) AS FaturamentoDiario
FROM Clientes
INNER JOIN Servicos ON Clientes.Id = Servicos.ClienteId
WHERE Servicos.Data = '2023-10-26'
GROUP BY Servicos.Data;


--DELETE  FROM Clientes
--WHERE Id=5
--SELECT * FROM Clientes