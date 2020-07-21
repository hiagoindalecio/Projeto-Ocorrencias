DROP DATABASE IF EXISTS db_ocorrencia;
CREATE DATABASE db_ocorrencia;
USE db_ocorrencia;
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `db_root`
--

DELIMITER $$
--
-- Procedimentos
--

CREATE DEFINER=`root`@`%` PROCEDURE `sp_deleteResp` (IN `pId_Usuario` INT, IN `pId_Departamento` INT)  NO SQL
BEGIN
	DELETE FROM tb_responsaveis 
    WHERE tb_responsaveis.id_usuario = pId_Usuario AND tb_responsaveis.id_departamento = pId_Departamento;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_editarDept` (IN `pNm_departamento` VARCHAR(50), IN `pId_departamento` INT)  BEGIN
    UPDATE tb_departamento
		SET nm_departamento = pNm_departamento 
	WHERE id_departamento = pId_departamento;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_editarroot` (IN `pId_departamento` INT, IN `pDs_defeito` VARCHAR(200), IN `pDs_solucao` VARCHAR(200), IN `pDt_entrada` DATE, IN `pDt_saida` DATE, IN `pNm_retirante` VARCHAR(50), IN `pDs_status` VARCHAR(30), IN `pNm_maquina` VARCHAR(50), IN `pId_usuario` INT, IN `pNr_root` INT)  BEGIN
    UPDATE TB_root
		SET ID_DEPARTAMENTO = pId_departamento,
			DS_DEFEITO = pDs_defeito,
			DS_SOLUCAO = pDs_solucao,
			DT_ENTRADA = pDt_entrada,
			DT_SAIDA = pDt_saida,
			NM_RETIRANTE = pNm_retirante,
			DS_STATUS = pDs_status,
			NM_MAQUINA = pNm_maquina,
			ID_USUARIO = pId_usuario
	WHERE NR_root = pNr_root;
    
    
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `sp_editarResp` (IN `pId_User` INT, IN `pId_Dept` INT)  NO SQL
BEGIN
    UPDATE tb_responsaveis
		SET ID_DEPARTAMENTO = pId_Dept,
            ID_USUARIO = pId_User
	WHERE ID_USUARIO = pId_User;
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `sp_editarUser` (IN `pNm_usuario` VARCHAR(80), IN `pDs_login` VARCHAR(50), IN `pDs_senha` VARCHAR(200), IN `pDs_perfil` VARCHAR(30), IN `pId_dept` INT, IN `pId_usuario` INT, IN `pemail` VARCHAR(80), IN `pDs_ativo` TINYINT)  NO SQL
BEGIN
    UPDATE TB_USUARIO
		SET NM_USUARIO = pNm_usuario,
			DS_LOGIN = pDs_login,
			DS_SENHA = pDs_senha,
			DS_PERFIL = pDs_perfil,
			ID_DEPARTAMENTO = pId_Dept,
            EMAIL = pemail,
            DS_ATIVO = pDs_ativo
	WHERE ID_USUARIO = pId_usuario;
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `sp_salvarAtendimento` (IN `pId_Departamento` INT, IN `pId_User` INT, IN `pNm_Solicitante` VARCHAR(30), IN `pNm_Maquina` VARCHAR(30), IN `pProblema` VARCHAR(200), IN `pSolucao` VARCHAR(200))  NO SQL
BEGIN
	INSERT INTO tb_historico_atendimento(id_user, id_departamento, nm_solicitante, nm_maquina, problema, solucao, dt_atendimento)
    VALUES(pId_User, pId_Departamento, pNm_Solicitante, pNm_Maquina, pProblema, pSolucao, now());
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_salvarDept` (IN `pNm_departamento` VARCHAR(50))  BEGIN
    INSERT INTO TB_DEPARTAMENTO(NM_DEPARTAMENTO)
						 VALUES(pNm_departamento);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_salvarHistorico` (IN `pDs_defeito` VARCHAR(200), IN `pDt_entrada` DATE, IN `pNm_maquina` VARCHAR(70), IN `pDs_status` VARCHAR(50), IN `pId_usuario` INT, IN `pNr_root` INT)  NO SQL
BEGIN
    INSERT INTO TB_HISTORICO(DS_DEFEITO , ID_USUARIO , NM_MAQUINA , DS_STATUS , DT_ENTRADA, NR_root)
   					 VALUES(pDs_defeito, pId_usuario, pNm_maquina, pDs_status, pDt_entrada, pNr_root);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_salvarroot` (IN `pId_departamento` INT, IN `pDs_defeito` VARCHAR(200), IN `pDs_solucao` VARCHAR(200), IN `pDt_entrada` DATE, IN `pDt_saida` DATE, IN `pNm_retirante` VARCHAR(50), IN `pDs_status` VARCHAR(30), IN `pNm_maquina` VARCHAR(50), IN `pId_usuario` INT)  BEGIN
    INSERT INTO TB_root(ID_DEPARTAMENTO, DS_DEFEITO, DS_SOLUCAO, DT_ENTRADA, DT_SAIDA, NM_RETIRANTE, DS_STATUS, NM_MAQUINA, ID_USUARIO)
						 VALUES(pId_departamento, pDs_defeito, pDs_solucao, pDt_entrada, pDt_saida, pNm_retirante, pDs_status, pNm_maquina, pId_usuario);
   
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `sp_salvarProcedimento` (IN `pDs_procedimento` VARCHAR(200), IN `pNr_root` INT, IN `pStatus_Atual` VARCHAR(15))  NO SQL
BEGIN
    INSERT INTO tb_procedimento(ds_procedimento, nr_root, dt_procedimento, status_atual)
						 VALUES(pDs_procedimento, pNr_root, now(), pStatus_Atual);
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `sp_salvarResponsavel` (IN `pId_Usuario` INT, IN `pId_Departamento` INT)  NO SQL
BEGIN
	INSERT INTO tb_responsaveis (id_usuario, id_Departamento)
    VALUES(pId_Usuario, pId_Departamento);
END$$

CREATE DEFINER=`root`@`%` PROCEDURE `sp_salvarUser` (IN `pNM_usuario` VARCHAR(80), IN `pDs_login` VARCHAR(50), IN `pDs_senha` VARCHAR(200), IN `pDs_perfil` VARCHAR(30), IN `pemail` VARCHAR(80), IN `pDs_ativo` TINYINT, IN `pId_departamento` INT)  NO SQL
BEGIN
    INSERT INTO TB_USUARIO(NM_USUARIO, DS_LOGIN, DS_SENHA, DS_PERFIL, EMAIL, DS_ATIVO, ID_DEPARTAMENTO)
						 VALUES(pNm_usuario, pDs_login, pDs_senha, pDs_perfil, pemail, pDs_ativo, pId_departamento);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_departamento`
--

CREATE TABLE `tb_departamento` (
  `id_departamento` int(11) NOT NULL,
  `nm_departamento` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tb_departamento`
--

INSERT INTO `tb_departamento` (`id_departamento`, `nm_departamento`) VALUES
(1, 'SAUDE'),
(2, 'EDUCAÇÃO'),
(3, 'TI'),
(4, 'GUARDA'),
(5, 'PATRIMONIO'),
(6, 'DESENVOLVIMENTO SOCIAL'),
(7, 'CULTURA'),
(8, 'CRAS CONVIVER'),
(9, 'OBRAS'),
(10, 'COMPRAS'),
(11, 'TESOURARIA'),
(12, 'COMUNICACAO'),
(13, 'GABINETE'),
(14, 'DEPARTAMENTO PESSOAL / RH'),
(15, 'IMPRESSORAS'),
(16, 'DES ECONOMICO');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_historico`
--

CREATE TABLE `tb_historico` (
  `dt_entrada` date NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `nm_maquina` varchar(50) NOT NULL,
  `ds_defeito` varchar(200) NOT NULL,
  `ds_status` varchar(50) NOT NULL,
  `nr_root` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tb_historico`
--

INSERT INTO `tb_historico` (`dt_entrada`, `id_usuario`, `nm_maquina`, `ds_defeito`, `ds_status`, `nr_root`) VALUES
('2019-12-09', 10, 'SAUDE_TESTE', 'TESTE', 'ABERTA', 79),
('2019-12-09', 10, 'SAUDE_TESTE', 'TESTE', 'EM MANUTENÇÃO', 79),
('2019-12-09', 10, 'SAUDE_TESTE', 'TESTE', 'AGUARDANDO PEÇA', 79),
('2019-12-09', 10, 'SAUDE_TESTE', 'TESTE', 'FASE DE TESTE', 79),
('2019-12-09', 10, 'SAUDE_TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 79),
('2019-12-09', 10, 'TESTE', 'TESTE', 'EM MANUTENÇÃO', 74),
('2019-12-09', 10, 'TESTE', 'TESTE', 'EM MANUTENÇÃO', 74),
('2019-12-09', 10, 'TESTE', 'TESTE', 'FASE DE TESTE', 74),
('2019-11-22', 7, 'SAUDE_31', 'TRAVANDO.', 'EM MANUTENÇÃO', 69),
('2019-11-22', 7, 'SAUDE_31', 'TRAVANDO.', 'FASE DE TESTE', 69),
('2019-12-12', 1, 'WWEF', 'WF', 'ABERTA', 80),
('2019-12-12', 13, 'WE', '23R2', 'ABERTA', 81),
('2019-12-09', 8, 'SAUDE_105', 'REINICIANDO SOZINHA', 'FASE DE TESTE', 77),
('2019-12-13', 7, 'GUARDA01', 'PAU', 'ABERTA', 82),
('2019-12-09', 8, 'SAUDE_105', 'REINICIANDO SOZINHA', 'AGUARDANDO RETIRADA', 77),
('2019-12-19', 7, 'SAUDE_094', 'MÁQUINA PEDINDO ATUALIZAÇÕES.', 'ABERTA', 83),
('2019-12-19', 7, 'SAUDE_094', 'MÁQUINA PEDINDO ATUALIZAÇÕES.', 'AGUARDANDO RETIRADA', 83),
('2019-12-20', 7, 'SAUDE_209', 'FALHA NA RELAÇÃO DE CONFIANÇA.', 'ABERTA', 84),
('2019-12-20', 7, 'RELOGIOPONTO09', 'LENTIDÃO EXECESSIVA.', 'ABERTA', 85),
('2019-12-20', 7, 'SAUDE_209', 'FALHA NA RELAÇÃO DE CONFIANÇA.', 'AGUARDANDO RETIRADA', 84),
('2019-12-20', 7, 'RELOGIOPONTO09', 'LENTIDÃO EXECESSIVA.', 'AGUARDANDO RETIRADA', 85),
('2020-01-06', 8, 'SAUDE_204', 'MAQUINA TRAVANDO CONFORME RELATORIO DA COLABORADORA.', 'ABERTA', 86),
('2020-01-06', 8, 'SAUDE_204', 'MAQUINA TRAVANDO CONFORME RELATORIO DA COLABORADORA.', 'EM MANUTENÇÃO', 86),
('2020-01-06', 8, 'SAUDE_204', 'MAQUINA TRAVANDO CONFORME RELATORIO DA COLABORADORA.', 'EM MANUTENÇÃO', 86),
('2020-01-06', 8, 'SAUDE_204', 'MAQUINA TRAVANDO CONFORME RELATORIO DA COLABORADORA.', 'EM MANUTENÇÃO', 86),
('2020-01-06', 8, 'GUARDA33', 'MAQUINA DE DOAÇÃO - FORMATAR', 'ABERTA', 87),
('2020-01-06', 8, 'GUARDA33', 'MAQUINA DE DOAÇÃO - FORMATAR', 'FASE DE TESTE', 87),
('2020-01-06', 8, 'TESTE', 'TESTE', 'ABERTA', 88),
('2020-01-06', 8, 'TESTE', 'TESTE', 'EM MANUTENÇÃO', 88),
('2020-01-06', 8, 'TESTE', 'TESTE', 'AGUARDANDO PEÇA', 88),
('2020-01-06', 8, 'TESTE', 'TESTE', 'FASE DE TESTE', 88),
('2020-01-06', 8, 'TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 88),
('2019-11-22', 7, 'SAUDE_31', 'TRAVANDO.', 'EM MANUTENÇÃO', 69),
('2019-11-22', 7, 'SAUDE_31', 'TRAVANDO.', 'AGUARDANDO RETIRADA', 69),
('2020-01-08', 11, 'CASA DA CULTURA', 'NÃO LIGA', 'ABERTA', 89),
('2020-01-08', 11, 'CASA DA CULTURA', 'NÃO LIGA', 'ABERTA', 90),
('2020-01-08', 11, 'CASA DA CULTURA', 'NÃO LIGA', 'AGUARDANDO PEÇA', 90),
('2020-01-09', 1, 'TESTE', 'TESTE\r\n', 'ABERTA', 91),
('2020-01-09', 1, 'TESTE2', 'TESTE2', 'ABERTA', 92),
('2020-01-09', 1, 'TESTE2', 'TESTE2', 'AGUARDANDO RETIRADA', 92),
('2020-01-09', 1, 'TESTE', 'TESTE', 'ABERTA', 93),
('2020-01-09', 1, 'TESTE', 'TESTE', 'ABERTA', 94),
('2020-01-09', 1, 'TESTE', 'TESTE', 'ABERTA', 95),
('2020-01-09', 11, 'CASA DA CULTURA 02', 'PASSAR ARQUIVOS DA CASA DA CULTURA QUE ESTA COM FONTE QUEIMADA', 'ABERTA', 96),
('2020-01-06', 8, 'SAUDE_204', 'MAQUINA TRAVANDO CONFORME RELATORIO DA COLABORADORA.', 'AGUARDANDO PEÇA', 86),
('2020-01-13', 7, 'TESTE', 'TESTE', 'ABERTA', 97),
('2020-01-13', 7, 'TESTE', 'TESTE', 'ABERTA', 98),
('2020-01-13', 7, 'TESTE', 'TESTE', 'ABERTA', 99),
('2020-01-13', 7, 'TESTE', 'TESTE\r\n', 'ABERTA', 100),
('2020-01-13', 7, 'TESTE', 'TESTE', 'ABERTA', 101),
('2020-01-13', 7, 'TESTE', 'TESTE', 'ABERTA', 102),
('2019-12-20', 7, 'SAUDE_209', 'FALHA NA RELAÇÃO DE CONFIANÇA.', 'AGUARDANDO RETIRADA', 84),
('2019-12-09', 8, 'SAUDE_105', 'REINICIANDO SOZINHA', 'AGUARDANDO RETIRADA', 77),
('2019-12-09', 8, 'SAUDE_105', 'REINICIANDO SOZINHA', 'AGUARDANDO RETIRADA', 77),
('2019-12-20', 7, 'SAUDE_209', 'FALHA NA RELAÇÃO DE CONFIANÇA.', 'AGUARDANDO RETIRADA', 84),
('2020-01-14', 7, 'TESTE', 'TESTE', 'ABERTA', 103),
('2020-01-14', 7, 'TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 103),
('2020-01-14', 7, 'TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 103),
('2020-01-14', 7, 'TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 103),
('2020-01-14', 7, 'TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 103),
('2020-01-14', 7, 'TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 103),
('2020-01-09', 11, 'CASA DA CULTURA 02', 'PASSAR ARQUIVOS DA CASA DA CULTURA QUE ESTA COM FONTE QUEIMADA', 'AGUARDANDO RETIRADA', 96),
('2020-01-14', 7, 'TESTE', 'TESTE', 'AGUARDANDO RETIRADA', 103),
('2020-01-14', 8, 'TESTE', 'TESTE\r\n', 'ABERTA', 104),
('2020-01-14', 8, 'TESTE', 'TESTE\r\n', 'AGUARDANDO RETIRADA', 104),
('2020-01-14', 11, 'SEMIDS_50', 'RELÓGIO PONTO NÃO LIGA, FICA CARREGANDO E VOLTA A TELA INICIAL', 'ABERTA', 105),
('2020-01-14', 11, 'SEMIDS_50', 'RELÓGIO PONTO NÃO LIGA, FICA CARREGANDO E VOLTA A TELA INICIAL', 'AGUARDANDO RETIRADA', 105),
('2020-01-15', 7, 'CASA DA CULTURA 02', 'ERRO DE DLL(KERNEL32.DLL)', 'ABERTA', 106),
('2020-01-15', 15, 'SAUDE - 186', 'ERRO NA RELAÇÃO DE CONFIANÇA', 'ABERTA', 107),
('2020-01-16', 8, 'TESTE', 'TESTE', 'ABERTA', 108),
('2020-01-15', 7, 'GUARDA_09', 'FORMATAR.', 'ABERTA', 109),
('2020-01-15', 7, 'GUARDA_09', 'TROCA DE HD.', 'ABERTA', 110),
('2020-01-15', 7, 'GUARDA_09', 'TROCA DE HD.', 'AGUARDANDO RETIRADA', 110),
('2020-01-16', 7, 'CRASPONTO', 'DATA  HORA ERRADA.', 'ABERTA', 111),
('2020-01-16', 7, 'BIBLIOTECA', 'NÃO LIGA.', 'ABERTA', 112),
('2020-01-16', 7, 'BIBLIOTECA', 'NÃO LIGA.', 'AGUARDANDO RETIRADA', 112),
('2020-01-16', 7, 'TESTE', 'TESTE', 'ABERTA', 113),
('2020-01-16', 7, 'TESTE', 'TESTE', 'AGUARDANDO PEÇA', 113),
('2020-01-16', 7, 'TESTE', 'TESTE', 'FASE DE TESTE', 113),
('2020-01-16', 7, 'TESTE', 'TESTE', 'AGUARDANDO PEÇA', 113),
('2020-01-16', 7, 'TESTE', 'TESTE', 'AGUARDANDO PEÇA', 113),
('2020-01-16', 7, 'TESTE', 'TESTE', 'AGUARDANDO PEÇA', 113),
('2020-01-16', 7, 'TESTE', 'TESTE', 'AGUARDANDO PEÇA', 113),
('2020-01-17', 7, 'SERVIDOR BIBLIOTECA', 'COPIAR SISTEMA DA BIBLIOTECA.', 'ABERTA', 114),
('2020-01-15', 15, 'SAUDE - 186', 'ERRO NA RELAÇÃO DE CONFIANÇA', 'AGUARDANDO RETIRADA', 107),
('2020-01-14', 11, 'SEMIDS_50', 'RELÓGIO PONTO NÃO LIGA, FICA CARREGANDO E VOLTA A TELA INICIAL', 'AGUARDANDO RETIRADA', 105),
('2020-01-17', 15, 'CASA DA CULTURA', 'TROCA DE SISTEMA OPERACIONAL E BACKUP', 'ABERTA', 115),
('2020-01-15', 7, 'CASA DA CULTURA 02', 'ERRO DE DLL(KERNEL32.DLL)', 'AGUARDANDO RETIRADA', 106),
('2020-01-21', 1, 'TESTE', 'TESTE', 'ABERTA', 116),
('2020-01-21', 1, 'TESTE', 'TESTE', 'AGUARDANDO PEÇA', 116),
('2020-01-21', 1, 'TESTE', 'TESTE', 'FASE DE TESTE', 116),
('2020-01-21', 1, 'TESTE', 'TESTE', 'FASE DE TESTE', 116),
('2020-01-21', 1, 'TESTE', 'TESTE', 'FASE DE TESTE', 116),
('2020-01-21', 1, 'TESTE', 'TESTE', 'EM MANUTENÇÃO', 116),
('2020-01-21', 1, 'TESTE', 'TESTE', 'EM MANUTENÇÃO', 116),
('2020-01-21', 1, 'TESTE', 'TESTE', 'EM MANUTENÇÃO', 116),
('2020-01-17', 7, 'SERVIDOR BIBLIOTECA', 'COPIAR SISTEMA DA BIBLIOTECA.', 'EM MANUTENÇÃO', 114),
('2020-01-17', 7, 'SERVIDOR BIBLIOTECA', 'COPIAR SISTEMA DA BIBLIOTECA.', 'AGUARDANDO RETIRADA', 114),
('2020-01-17', 7, 'SERVIDOR BIBLIOTECA', 'COPIAR SISTEMA DA BIBLIOTECA.', 'AGUARDANDO RETIRADA', 114),
('2020-01-27', 8, 'SEMIDS_50', 'MAQUINA PONTO, CONFORME DESCRICAO ENVIADA, MAQUINA PAROU DE INICIAR APOS QUEDA DE ENERGIA.', 'ABERTA', 117),
('2020-01-27', 8, 'SEMIDS_50', 'MAQUINA PONTO, CONFORME DESCRICAO ENVIADA, MAQUINA PAROU DE INICIAR APOS QUEDA DE ENERGIA.', 'EM MANUTENÇÃO', 117),
('2020-01-28', 8, 'RELOGIOPONTO04', 'MAQUINA REINICIANDO, NECESSITA TROCA DE BATERIA E LIMPEZA.', 'ABERTA', 118),
('2020-01-28', 8, 'RELOGIOPONTO04', 'MAQUINA REINICIANDO, NECESSITA TROCA DE BATERIA E LIMPEZA.', 'AGUARDANDO RETIRADA', 118),
('2020-01-27', 8, 'SEMIDS_50', 'MAQUINA PONTO, CONFORME DESCRICAO ENVIADA, MAQUINA PAROU DE INICIAR APOS QUEDA DE ENERGIA.', 'EM MANUTENÇÃO', 117),
('2020-01-27', 8, 'SEMIDS_50', 'MAQUINA PONTO, CONFORME DESCRICAO ENVIADA, MAQUINA PAROU DE INICIAR APOS QUEDA DE ENERGIA.', 'EM MANUTENÇÃO', 117),
('2020-01-29', 11, 'COMPRAS03', 'ESTAGIARIO IAGO TROUXE A MÁQUINA POIS NÃO ESTAVA CONSEGUINDO INSTALAR A IMPRESSORA BROTHER E O SCANNER EPSON', 'ABERTA', 119),
('2020-01-29', 11, 'COMPRAS03', 'ESTAGIARIO IAGO TROUXE A MÁQUINA POIS NÃO ESTAVA CONSEGUINDO INSTALAR A IMPRESSORA BROTHER E O SCANNER EPSON', 'AGUARDANDO RETIRADA', 119),
('2020-01-30', 12, 'VLADIA', 'MAQUINA NOVA - COLOCAR NO DOMINIO E EINSTALAR SOFTWARES PADRAO', 'ABERTA', 120),
('2020-01-30', 12, 'VLADIA', 'MAQUINA NOVA - COLOCAR NO DOMINIO E EINSTALAR SOFTWARES PADRAO', 'EM MANUTENÇÃO', 120),
('2020-01-30', 12, 'VLADIA', 'MAQUINA NOVA - COLOCAR NO DOMINIO E EINSTALAR SOFTWARES PADRAO', 'AGUARDANDO RETIRADA', 120),
('2020-01-27', 8, 'SEMIDS_50', 'MAQUINA PONTO, CONFORME DESCRICAO ENVIADA, MAQUINA PAROU DE INICIAR APOS QUEDA DE ENERGIA.', 'AGUARDANDO RETIRADA', 117),
('2020-02-03', 12, 'LENOVO', 'DESLIGANDO SOZINHO', 'ABERTA', 121),
('2020-02-03', 12, 'SAUDE_230', 'REINSTALAÇÃO DO WIN_PRO', 'ABERTA', 122),
('2020-02-03', 8, 'SAUDE_230', 'FORMATAÇÃO E INSTALAÇÃO DE WIN10 PRO. ', 'ABERTA', 123),
('2020-02-04', 7, 'SAUDE_015', 'DESLIGANDO SOZINHA.', 'ABERTA', 124),
('2020-02-04', 12, 'CONTABIL_08', 'UPGRADE DE MEMÓRIA E LIMPEZA', 'ABERTA', 125),
('2020-02-04', 7, 'SAUDE_015', 'DESLIGANDO SOZINHA.', 'EM MANUTENÇÃO', 124),
('2020-02-04', 7, 'SAUDE_015', 'DESLIGANDO SOZINHA.', 'AGUARDANDO PEÇA', 124),
('2020-01-06', 8, 'SAUDE_204', 'MAQUINA TRAVANDO CONFORME RELATORIO DA COLABORADORA.', 'AGUARDANDO PEÇA', 86),
('2020-02-05', 12, 'SAUDE_049', 'LENTO', 'ABERTA', 126),
('2020-02-05', 1, 'IBER342218094IH', 'TROCA DE CILINDRO.', 'ABERTA', 127),
('2020-02-05', 1, 'IBER342218094IH', 'TROCA DE CILINDRO.', 'EM MANUTENÇÃO', 127),
('2020-02-05', 1, 'BRBR32U39UF', 'GAY.', 'EM MANUTENÇÃO', 127),
('2020-02-05', 1, 'USANUE34249F', 'MANCHADO.', 'FASE DE TESTE', 127);

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_historicousuario`
--

CREATE TABLE `tb_historicousuario` (
  `dt_alteracao` date DEFAULT NULL,
  `id_usuario` int(11) NOT NULL,
  `id_usuarioAlterado` int(11) NOT NULL,
  `ds_ativo` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_historico_atendimento`
--

CREATE TABLE `tb_historico_atendimento` (
  `id_atendimento` int(11) NOT NULL,
  `id_departamento` int(11) NOT NULL,
  `id_user` int(11) NOT NULL,
  `nm_solicitante` varchar(30) NOT NULL,
  `nm_maquina` varchar(30) NOT NULL,
  `problema` varchar(200) NOT NULL,
  `solucao` varchar(200) NOT NULL,
  `dt_atendimento` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tb_historico_atendimento`
--

INSERT INTO `tb_historico_atendimento` (`id_atendimento`, `id_departamento`, `id_user`, `nm_solicitante`, `nm_maquina`, `problema`, `solucao`, `dt_atendimento`) VALUES
(1, 8, 8, 'Deise', 'impressora', 'tonner vazio', 'solicitou tonner. vai mandar motorista buscar.', '2020-02-04 10:41:07'),
(2, 11, 12, 'Leonardo', 'contabilidade_03', 'solicitou uma maquina a mais no setor', 'Instalada', '2020-02-04 11:02:13'),
(3, 14, 8, 'Caio', 'rh_05', 'instalar dirf 64bits', 'instalado', '2020-02-04 10:49:15');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_ocorrencia`
--

CREATE TABLE `tb_ocorrencia` (
  `nr_ocorrencia` int(11) NOT NULL,
  `id_departamento` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `ds_defeito` varchar(200) DEFAULT NULL,
  `ds_solucao` varchar(200) DEFAULT NULL,
  `dt_entrada` date DEFAULT NULL,
  `dt_saida` date DEFAULT NULL,
  `nm_retirante` varchar(50) DEFAULT NULL,
  `nm_maquina` varchar(50) DEFAULT NULL,
  `ds_status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tb_ocorrencia`
--

INSERT INTO `tb_ocorrencia` (`nr_ocorrencia`, `id_departamento`, `id_usuario`, `ds_defeito`, `ds_solucao`, `dt_entrada`, `dt_saida`, `nm_retirante`, `nm_maquina`, `ds_status`) VALUES
(54, 4, 1, 'ANTIGO GABINETE03\r\nFORMATAR P/ GUARDA', '', '2019-11-08', '2019-11-25', '', 'GUARDA32', 'ENTREGUE'),
(55, 1, 1, 'FORMATAR', '', '2019-11-08', '2019-11-22', 'MOTORISTA', 'SAUDE_104', 'ENTREGUE'),
(56, 2, 1, 'TESTE', 'TESTE', '2019-11-08', '2020-01-31', 'NINGUÉM', 'TESTE', 'ENTREGUE'),
(57, 3, 1, 'ABCDE', 'FORMATADO', '2019-11-08', '2019-11-08', 'MOTORISTA X', 'INFORMATICAO1', 'ENTREGUE'),
(58, 5, 1, 'FORMATAR', '', '2019-11-11', '2019-12-04', '', 'PATRIMONIO03', 'ENTREGUE'),
(59, 5, 7, 'FORMATAÇÃO.', '', '2019-11-11', '2019-12-04', '', 'PATRIMONIO_01', 'ENTREGUE'),
(60, 1, 10, 'TESTE', 'HH', '2019-11-13', '2019-11-13', 'H', 'TESTE', 'ENTREGUE'),
(62, 1, 10, '123', '123', '2019-11-13', '2019-11-13', '123', '123', 'ENTREGUE'),
(63, 2, 10, '123', 'WERT', '2019-11-13', '2019-11-14', 'ETWT', '123', 'ENTREGUE'),
(64, 1, 10, '123123', 'WERT', '2019-11-13', '2019-11-14', 'WERT', '3123', 'ENTREGUE'),
(65, 3, 10, 'QWE', 'WER', '2019-11-13', '2019-11-14', 'WER', 'QWE', 'ENTREGUE'),
(66, 2, 10, 'ASDFASDF', 'EWRWER', '2019-11-14', '2019-11-14', '', 'FASDF', 'ENTREGUE'),
(67, 6, 1, 'MÁQUINA DESLIGANDO.', '', '2019-11-19', '2019-12-05', '', 'SEMIOS_59', 'ENTREGUE'),
(68, 1, 1, 'DESLIGANDO.', '', '2019-11-19', '2019-11-25', '', 'SAUDE_110', 'ENTREGUE'),
(69, 1, 7, 'TRAVANDO.', '', '2019-11-22', '2020-02-03', 'MOTORISTA', 'SAUDE_31', 'ENTREGUE'),
(70, 1, 1, 'MAQUINA TRAVANDO', '', '2019-11-28', '2019-12-12', 'MOTORISTA', 'SAUDE_204', 'ENTREGUE'),
(71, 1, 7, 'DESLIGANDO.', 'root DUPLICADA.', '2019-11-29', '2019-12-03', 'DUPLICADA', 'SAUDE_163', 'ENTREGUE'),
(74, 4, 10, 'TESTE', 'TESTE', '2019-12-09', '2019-12-11', 'TESTE', 'TESTE', 'ENTREGUE'),
(75, 1, 8, 'PASSAR OS DADOS DO SAUDE_015', '', '2019-12-09', '2019-12-12', 'MOTORISTA', 'SAUDE_229', 'ENTREGUE'),
(76, 1, 8, 'PASSAR OS DADOS PARA MICRO NOVO DA DENISE (SAUDE_229) E FORMATAR.', 'ENVIADA AO PADOVANI\r\n', '2019-12-09', '2019-12-18', 'MOTORISTA', 'SAUDE_015', 'ENTREGUE'),
(77, 1, 8, 'REINICIANDO SOZINHA', '', '2019-12-09', '2020-02-04', 'ANTONIO', 'SAUDE_105', 'ENTREGUE'),
(78, 6, 13, 'WTWQ', '', '2019-12-09', '2019-12-09', '', 'WET', 'ENTREGUE'),
(79, 1, 10, 'TESTE', 'TROCADO MEMORIA E TESTATO.\r\nOK.', '2019-12-09', '2019-12-09', 'MOTORISTA TAL', 'SAUDE_TESTE', 'ENTREGUE'),
(80, 4, 1, 'WF', '', '2019-12-12', '2019-12-12', '', 'WWEF', 'BAIXA'),
(81, 4, 13, '23R2', '', '2019-12-12', '2019-12-12', '', 'WE', 'BAIXA'),
(82, 4, 7, 'PAU', 'ISTO FOI UM TESTE.', '2019-12-13', '2019-12-13', 'NINGUÉM', 'GUARDA01', 'ENTREGUE'),
(83, 1, 7, 'MÁQUINA PEDINDO ATUALIZAÇÕES.', '', '2019-12-19', '2020-02-04', 'ANTONIO', 'SAUDE_094', 'ENTREGUE'),
(84, 1, 7, 'FALHA NA RELAÇÃO DE CONFIANÇA.', '', '2019-12-20', '2020-01-29', 'NAO MARCADO', 'SAUDE_209', 'ENTREGUE'),
(85, 1, 7, 'LENTIDÃO EXECESSIVA.', 'FOI FEITA ATUALIZAÇÕA DA MÁQUINA E O PONTO ELETRÔNICO FOI REINSTALADO.', '2019-12-20', '2020-01-08', 'PEDRO', 'RELOGIOPONTO09', 'ENTREGUE'),
(86, 1, 8, 'MAQUINA TRAVANDO CONFORME RELATORIO DA COLABORADORA.', '', '2020-01-06', '0001-01-01', '', 'SAUDE_204', 'AGUARDANDO PEÇA'),
(87, 4, 8, 'MAQUINA DE DOAÇÃO - FORMATAR', 'OK', '2020-01-06', '2020-01-08', 'GUARDA', 'GUARDA33', 'ENTREGUE'),
(88, 6, 8, 'TESTE', 'FORMATADA E OK', '2020-01-06', '2020-01-06', 'TESTE', 'TESTE', 'ENTREGUE'),
(89, 7, 11, 'NÃO LIGA', 'DUPLICADO', '2020-01-08', '2020-01-08', '', 'CASA DA CULTURA', 'ENTREGUE'),
(90, 7, 11, 'NÃO LIGA', '', '2020-01-08', '0001-01-01', '', 'CASA DA CULTURA', 'AGUARDANDO PEÇA'),
(91, 3, 1, 'TESTE\r\n', 'WWE', '2020-01-09', '2020-01-09', 'WD', 'TESTE', 'ENTREGUE'),
(92, 3, 1, 'TESTE2', '', '2020-01-09', '2020-01-09', '', 'TESTE2', 'ENTREGUE'),
(93, 7, 1, 'TESTE', '', '2020-01-09', '2020-01-09', '', 'TESTE', 'BAIXA'),
(94, 7, 1, 'TESTE', '', '2020-01-09', '2020-01-09', '', 'TESTE', 'ENTREGUE'),
(95, 7, 1, 'TESTE', 'TESTE', '2020-01-09', '2020-01-10', 'NIGUÉM', 'TESTE', 'ENTREGUE'),
(96, 7, 11, 'PASSAR ARQUIVOS DA CASA DA CULTURA QUE ESTA COM FONTE QUEIMADA', '', '2020-01-09', '2020-01-14', 'MOTORISTA', 'CASA DA CULTURA 02', 'ENTREGUE'),
(97, 7, 7, 'TESTE', 'EFWE', '2020-01-13', '2020-01-13', 'VFDF', 'TESTE', 'ENTREGUE'),
(98, 7, 7, 'TESTE', 'ERG', '2020-01-13', '2020-01-13', 'FEG', 'TESTE', 'ENTREGUE'),
(99, 7, 7, 'TESTE', '', '2020-01-13', '2020-01-13', '', 'TESTE', 'ENTREGUE'),
(100, 7, 7, 'TESTE\r\n', '', '2020-01-13', '2020-01-13', '', 'TESTE', 'ENTREGUE'),
(101, 7, 7, 'TESTE', '', '2020-01-13', '2020-01-13', '', 'TESTE', 'ENTREGUE'),
(102, 7, 7, 'TESTE', '', '2020-01-13', '2020-01-13', '', 'TESTE', 'ENTREGUE'),
(103, 4, 7, 'TESTE', '', '2020-01-14', '2020-01-14', '', 'TESTE', 'ENTREGUE'),
(104, 5, 8, 'TESTE\r\n', '', '2020-01-14', '2020-01-14', 'NINGUÉM', 'TESTE', 'ENTREGUE'),
(105, 8, 11, 'RELÓGIO PONTO NÃO LIGA, FICA CARREGANDO E VOLTA A TELA INICIAL', 'MÁQUINA FOI RETIRADA DO DOMINIO E FOI COLOCADA NOVAMENTE CORRIGINDO A FALHA NA RELAÇÃO DE CONFIANÇA', '2020-01-14', '2020-01-17', 'MOTORISTA CRAS', 'SEMIDS_50', 'ENTREGUE'),
(106, 7, 7, 'ERRO DE DLL(KERNEL32.DLL)', '', '2020-01-15', '2020-01-29', 'NAO MARCADO', 'CASA DA CULTURA 02', 'ENTREGUE'),
(107, 1, 15, 'ERRO NA RELAÇÃO DE CONFIANÇA', '', '2020-01-15', '2020-01-29', 'NAO MARCADO', 'SAUDE - 186', 'ENTREGUE'),
(108, 2, 8, 'TESTE', 'TESTE', '2020-01-16', '2020-01-16', 'TESTE', 'TESTE', 'BAIXA'),
(109, 8, 7, 'FORMATAR.', '', '2020-01-15', '2020-01-16', '', 'GUARDA_09', 'ENTREGUE'),
(110, 4, 7, 'TROCA DE HD.', 'O HD FOI TROCADA E FOI REALIZADA A FORMATAÇÃO', '2020-01-15', '2020-01-24', 'GUARDA LUIS ANTÔNIO', 'GUARDA_09', 'ENTREGUE'),
(111, 8, 7, 'DATA  HORA ERRADA.', 'TROCA DE BATERIA DA BIOS.', '2020-01-16', '2020-01-16', 'MOTORISTA', 'CRASPONTO', 'ENTREGUE'),
(112, 7, 7, 'NÃO LIGA.', 'MAQUINA PRONTA QUARDADA NO TI', '2020-01-16', '2020-01-30', 'TI', 'BIBLIOTECA', 'ENTREGUE'),
(113, 3, 7, 'TESTE', '', '2020-01-16', '2020-01-17', '', 'TESTE', 'ENTREGUE'),
(114, 7, 7, 'COPIAR SISTEMA DA BIBLIOTECA.', 'MAQUINA ENTREGUE E INSTALADA E TESTADA POR FELIPE E EWERTON NA BIBLIOTECA', '2020-01-17', '2020-01-30', 'LEVADA AO LOCAL', 'SERVIDOR BIBLIOTECA', 'ENTREGUE'),
(115, 7, 15, 'TROCA DE SISTEMA OPERACIONAL E BACKUP', NULL, '2020-01-17', '0001-01-01', NULL, 'CASA DA CULTURA', 'ABERTA'),
(116, 5, 1, 'TESTE', 'NADA', '2020-01-21', '2020-01-31', 'NINGUÉM', 'TESTE', 'ENTREGUE'),
(117, 8, 8, 'MAQUINA PONTO, CONFORME DESCRICAO ENVIADA, MAQUINA PAROU DE INICIAR APOS QUEDA DE ENERGIA.', 'LEVOU', '2020-01-27', '2020-01-30', 'MARCOS', 'SEMIDS_50', 'ENTREGUE'),
(118, 9, 8, 'MAQUINA REINICIANDO, NECESSITA TROCA DE BATERIA E LIMPEZA.', 'MÁQUINA ENTREGA.', '2020-01-28', '2020-01-29', 'PEDRO', 'RELOGIOPONTO04', 'ENTREGUE'),
(119, 10, 11, 'ESTAGIARIO IAGO TROUXE A MÁQUINA POIS NÃO ESTAVA CONSEGUINDO INSTALAR A IMPRESSORA BROTHER E O SCANNER EPSON', '', '2020-01-29', '0001-01-01', '', 'COMPRAS03', 'AGUARDANDO RETIRADA'),
(120, 1, 12, 'MAQUINA NOVA - COLOCAR NO DOMINIO E EINSTALAR SOFTWARES PADRAO', 'PRONTO', '2020-01-30', '2020-02-04', 'FELIPE', 'VLADIA', 'ENTREGUE'),
(121, 1, 12, 'DESLIGANDO SOZINHO', '100.111.13.116 FEITO LIMPEZA - NO USUÁRIO SUPORTE NÃO DESLIGOU ...', '2020-02-03', '2020-02-04', 'ANTONIO', 'LENOVO', 'ENTREGUE'),
(122, 10, 12, 'REINSTALAÇÃO DO WIN_PRO', 'ABERTO ERRADO! ', '2020-02-03', '0001-01-01', NULL, 'SAUDE_230', 'BAIXA'),
(123, 1, 8, 'FORMATAÇÃO E INSTALAÇÃO DE WIN10 PRO. ', 'FORMATADO E INSTALADO OS PROGRAMAS PADROES. \r\nCOLOCADO NO DOMINIO.', '2020-02-03', '2020-02-04', 'ANTONIO', 'SAUDE_230', 'ENTREGUE'),
(124, 1, 7, 'DESLIGANDO SOZINHA.', '', '2020-02-04', '0001-01-01', '', 'SAUDE_015', 'AGUARDANDO PEÇA'),
(125, 3, 12, 'UPGRADE DE MEMÓRIA E LIMPEZA', 'ADICIONADO\r\n', '2020-02-04', '2020-02-04', 'LEONARDO', 'CONTABIL_08', 'ENTREGUE'),
(126, 10, 12, 'LENTO', 'ADICIONADO + MEMORIA RAM E CHAVE DO WINDOWS.', '2020-02-05', '2020-02-05', 'ANA', 'SAUDE_049', 'ENTREGUE'),
(127, 15, 1, 'MANCHADO.', '', '2020-02-05', '0001-01-01', NULL, 'USANUE34249F', 'FASE DE TESTE');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_procedimento`
--

CREATE TABLE `tb_procedimento` (
  `nr_root` int(11) NOT NULL,
  `ds_procedimento` varchar(200) NOT NULL,
  `dt_procedimento` date NOT NULL,
  `status_atual` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tb_procedimento`
--

INSERT INTO `tb_procedimento` (`nr_ocorrencia`, `ds_procedimento`, `dt_procedimento`, `status_atual`) VALUES
(79, 'TROCADO MEMORIA', '2019-12-09', 'EM MANUTENÇÃO'),
(79, 'MEMORIA QUEIMADA', '2019-12-09', 'EM MANUTENÇÃO'),
(79, 'MEMORIA EM TESTE', '2019-12-09', 'EM MANUTENÇÃO'),
(79, 'OK!', '2019-12-09', 'EM MANUTENÇÃO'),
(74, 'TESTE.', '2019-12-10', 'EM MANUTENÇÃO'),
(74, 'FGJ', '2019-12-10', 'EM MANUTENÇÃO'),
(74, 'ETYJ', '2019-12-10', 'EM MANUTENÇÃO'),
(69, 'VERIFICADO QUE O HD ESTÁ CHEIO. ', '2019-12-10', 'EM MANUTENÇÃO'),
(69, 'PASSADO CCLEANER ', '2019-12-10', 'EM MANUTENÇÃO'),
(77, 'TESTE DE FUNCIONAMENTO', '2019-12-12', 'EM MANUTENÇÃO'),
(77, 'MÁQUINA ZERADA, PROBLEMA NO HD.', '2019-12-19', 'EM MANUTENÇÃO'),
(83, 'MÁQUINA ATUALIZADA.', '2019-12-20', 'EM MANUTENÇÃO'),
(84, 'A MÁQUINA FOI RETIRADA DO DOMINIO, RECOLOCADA NO DOMINIO E ATUALIZADA.', '2020-01-03', 'EM MANUTENÇÃO'),
(85, 'A MÁQUINA FOI ATUALIZADA E FOI REALIZADO TESTES COMLEITOR A MÁQUINA ESTÁ PRONTA PARA USO.', '2020-01-03', 'EM MANUTENÇÃO'),
(86, 'MAQUINA MUITO LENTA, NÃO ABRE INSTALAÇÃO DO W10.', '2020-01-06', 'EM MANUTENÇÃO'),
(86, 'SEGUNDO RENAN, FOI AVISADO A ANDREA DA SAUDE, SOBRE A MAQUINA SER DA MAESTRO, ESTÁ AGUARDANDO RETORNO.', '2020-01-06', 'EM MANUTENÇÃO'),
(86, 'APARENTEMENTE PROBLEMA DE HD! ', '2020-01-06', 'EM MANUTENÇÃO'),
(87, 'ATUALIZANDO', '2020-01-06', 'EM MANUTENÇÃO'),
(88, 'TESTE1', '2020-01-06', 'EM MANUTENÇÃO'),
(88, 'TESTE2', '2020-01-06', 'EM MANUTENÇÃO'),
(88, 'TESTE3', '2020-01-06', 'EM MANUTENÇÃO'),
(88, 'OK', '2020-01-06', 'EM MANUTENÇÃO'),
(69, 'HD CHEIO', '2020-01-08', 'EM MANUTENÇÃO'),
(69, 'AVISAR O USUÁRIO QUE O HD ESTÁ CHEIO.', '2020-01-08', 'EM MANUTENÇÃO'),
(90, 'FONTE QUEIMADA.', '2020-01-08', 'EM MANUTENÇÃO'),
(92, 'TESTE', '2020-01-09', 'EM MANUTENÇÃO'),
(86, 'NECESSARIO TROCA DE HD', '2020-01-10', 'EM MANUTENÇÃO'),
(84, 'PRONTA', '2020-01-14', 'EM MANUTENÇÃO'),
(77, 'PRONTA', '2020-01-14', 'EM MANUTENÇÃO'),
(77, 'PRONTA', '2020-01-14', 'EM MANUTENÇÃO'),
(77, 'PRONTA', '2020-01-14', 'EM MANUTENÇÃO'),
(84, 'PRONTA', '2020-01-14', 'EM MANUTENÇÃO'),
(103, 'PRONTA', '2020-01-14', 'EM MANUTENÇÃO'),
(103, 'PRONTA', '2020-01-14', 'EM MANUTENÇÃO'),
(103, 'RGH', '2020-01-14', 'EM MANUTENÇÃO'),
(103, 'FRW', '2020-01-14', 'EM MANUTENÇÃO'),
(103, 'FE', '2020-01-14', 'EM MANUTENÇÃO'),
(103, 'FDSDG', '2020-01-14', 'EM MANUTENÇÃO'),
(96, 'ARQUIVOS DO BACKUP FEITOS COM SUCESSO.', '2020-01-14', 'EM MANUTENÇÃO'),
(103, 'EHEH', '2020-01-14', 'EM MANUTENÇÃO'),
(104, 'TESTE', '2020-01-14', 'EM MANUTENÇÃO'),
(105, 'FOI FEITA A FORMATAÇÃO DA MÁQUINA E INSTALAÇÃO DO PONTO ELETRÔNICO NOVAMENTE', '2020-01-14', 'EM MANUTENÇÃO'),
(110, 'FORMATADA', '2020-01-16', 'EM MANUTENÇÃO'),
(112, 'PRONTA.', '2020-01-16', 'EM MANUTENÇÃO'),
(113, 'PRECISA DE FONTE NOVA.', '2020-01-16', 'EM MANUTENÇÃO'),
(113, 'LIGADA PARA TESTES.', '2020-01-16', 'EM MANUTENÇÃO'),
(113, 'PRECISA DE UMA NOVA FONTE.', '2020-01-16', 'EM MANUTENÇÃO'),
(113, 'FODA-SE', '2020-01-16', 'EM MANUTENÇÃO'),
(113, 'FODA-SE.', '2020-01-16', 'EM MANUTENÇÃO'),
(113, 'FODA-SE.', '2020-01-16', 'EM MANUTENÇÃO'),
(107, 'MÁQUINA FOI RETIRADA DO DOMINIO E INGRESSADA NOVAMENTE.', '2020-01-17', 'EM MANUTENÇÃO'),
(105, 'MÁQUINA FOI FORMATADA E O PONTO FOI REINSTALADO, FUNCIONANDO NORMALMENTE.', '2020-01-17', 'EM MANUTENÇÃO'),
(106, ' ', '2020-01-20', 'EM MANUTENÇÃO'),
(116, 'TESTE', '2020-01-21', 'EM MANUTENÇÃO'),
(116, 'TESTANDO ESSA MERDA.', '2020-01-21', 'EM MANUTENÇÃO'),
(116, 'TESTANDO ESSA BOSTA.', '2020-01-21', 'EM MANUTENÇÃO'),
(116, 'SEI LÁ.', '2020-01-21', 'EM MANUTENÇÃO'),
(116, 'D', '2020-01-21', 'EM MANUTENÇÃO'),
(116, 'GN', '2020-01-21', 'EM MANUTENÇÃO'),
(116, 'TESTE', '2020-01-21', 'EM MANUTENÇÃO'),
(114, 'SISTEMA MUITO ANTIGO, NÃO VALE A PENA MIGRAR.', '2020-01-27', 'EM MANUTENÇÃO'),
(114, 'OK', '2020-01-27', 'EM MANUTENÇÃO'),
(114, 'OK', '2020-01-27', 'EM MANUTENÇÃO'),
(117, 'PROBLEMA DE HD, TENTANDO RECUPERAR.', '2020-01-27', 'EM MANUTENÇÃO'),
(118, 'TROCA DE GABINETE, \r\nPAT: 22033 -> 25356', '2020-01-28', 'EM MANUTENÇÃO'),
(117, 'TROCADO HD, INSTALADO S.O. E RELOGIO PONTO. \r\nAGUARDANDO COD DE LIBERAÇÃO DO PONTO.', '2020-01-29', 'EM MANUTENÇÃO'),
(117, 'AGUARDANDO COD DE LIBERAÇÃO DO RELOGIO PONTO.', '2020-01-29', 'EM MANUTENÇÃO'),
(119, 'FOI REALIZADA A RESTAURAÇÃO DO SISTEMA E ATUALIZAÇÃO NA MÁQUINA.', '2020-01-29', 'EM MANUTENÇÃO'),
(120, 'MAQUINA PRONTA\r\n', '2020-01-30', 'EM MANUTENÇÃO'),
(120, 'MAQUINA PRONTA', '2020-01-30', 'EM MANUTENÇÃO'),
(117, 'MAQUINA PRONTA.', '2020-01-30', 'EM MANUTENÇÃO'),
(124, 'FEITO LIMPEZA, POREM FOI CONSTATADO DEFEITO NA FONTE. ', '2020-02-04', 'EM MANUTENÇÃO'),
(124, 'DEFEITO DE FONTE, POREM NÃO ACHA PARA COMPRAR.', '2020-02-04', 'AGUARDANDO PEÇA'),
(86, 'MAQUINA + MONITOR DA MAESTRO, AGUARDANDO GARANTIA.', '2020-02-04', 'AGUARDANDO PEÇA'),
(127, 'WFE', '2020-02-05', 'EM MANUTENÇÃO'),
(127, 'DVFEQ', '2020-02-05', 'EM MANUTENÇÃO'),
(127, 'CHAMADO ABERTO.', '2020-02-05', 'FASE DE TESTE');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_responsaveis`
--

CREATE TABLE `tb_responsaveis` (
  `id_usuario` int(11) NOT NULL,
  `id_departamento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tb_responsaveis`
--

INSERT INTO `tb_responsaveis` (`id_usuario`, `id_departamento`) VALUES
(10, 1),
(12, 3),
(14, 2),
(23, 7),
(24, 8),
(25, 9);

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_usuario`
--

CREATE TABLE `tb_usuario` (
  `id_usuario` int(11) NOT NULL,
  `nm_usuario` varchar(80) NOT NULL,
  `ds_login` varchar(50) NOT NULL,
  `ds_senha` varchar(200) NOT NULL,
  `ds_perfil` varchar(30) NOT NULL,
  `email` varchar(80) NOT NULL,
  `ds_ativo` tinyint(1) DEFAULT NULL,
  `id_departamento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tb_usuario`
--

INSERT INTO `tb_usuario` (`id_usuario`, `nm_usuario`, `ds_login`, `ds_senha`, `ds_perfil`, `email`, `ds_ativo`, `id_departamento`) VALUES
(1, 'ADMINISTRADOR', 'admin', '2f5bffeaedff11230a39f4d3d4a2b8f5df65fa5acf6d0a874a59fa21db652ac0d38c0b70ab5e014609900aba135c7893d4fa3e9e819ba69b8ed5186247810703', 'ADMINISTRADOR', 'suporte.ti@capivari.sp.gov.br', 1, 3),
(6, 'EDUCACAO', 'educacao', 'c60917485a6e68922f8c9b5e4fdcd89714131eab24804c13eabc6ad293d08a0a030f54a823775f76e6c8c9fc1bae767741f74ea25967e1087605a27a8f8d9eaf', 'TÉCNICO', 'suporte.ti@capivari.sp.gov.br', 0, 2),
(7, 'HIAGO.INDALECIO', 'techiago', '2f5bffeaedff11230a39f4d3d4a2b8f5df65fa5acf6d0a874a59fa21db652ac0d38c0b70ab5e014609900aba135c7893d4fa3e9e819ba69b8ed5186247810703', 'TÉCNICO', 'hiagoindalecio@gmail.com', 1, 3),
(8, 'FELIPE SILVA', 'felipe', 'c466d639480b36ca8df13d4720d76a25821544aa420f23bf2c9b5cbdfe808ff1d074845543877596f2b38c8d01ae622fb7eb3fee1891f459299847fdbb293581', 'ADMINISTRADOR', 'felipe@capivari.sp.gov.br', 1, 3),
(10, 'ANDREA COPELLI FERRAZ', 'andrea', '2f5bffeaedff11230a39f4d3d4a2b8f5df65fa5acf6d0a874a59fa21db652ac0d38c0b70ab5e014609900aba135c7893d4fa3e9e819ba69b8ed5186247810703', 'TÉCNICO', 'saude_sistemas@capivari.sp.gov.br', 1, 1),
(11, 'RENAN MARTINS GABRIEL', 'renan', '161c8ce54be74b5d9c5d19e38c9ce6a10ecf3f59f9550434dd8861430ee51311e02c8db461303c144b9f9dbeeeeebf179a94c120e89c4da83301224872e64bbd', 'ADMINISTRADOR', 'renan.tecnico@capivari.sp.gov.br', 1, 3),
(12, 'EWERTON', 'ewerton', '43ecbb198d513088eb1263c2b5b97ad3a05fe4837cfc8b3b69f461277bd5525c1d1a296b0d574220ab5c217463c3a19461e40a9509ea21c4ba158b7e25196294', 'ADMINISTRADOR', 'informatica@capivari.sp.gov.br', 1, 3),
(13, 'FULANO DE TAL', 'fulano', 'e1223d9bbcd82236f9f09ae1f5578e3cbbd4e8f48954cead3003be60ac85629726dc04b1f875353459f97ba4a4283a1a6adb89d3524bb4816c7125964097106c', 'OPERADOR', 'fulano@nada.com', 0, 4),
(14, 'BRUNO POMPEU', 'bruno', '8df966b67473aceeb2a722e68dc7a5e7056bfc594cc01869318f4df554da96744a8069ac5eed1897fd3230f3e63c2ec9bfed19321233de76bc9a8c700777e63c', 'ADMINISTRADOR', 'suporte.ti@capivari.sp.gov.br', 1, 3),
(15, 'PATRICK', 'patrick.barbosa', '14474d3e747092839abf2dcf30e6d06b47338a61c0ce81723e88a8185927bcd834035357d2e35e2944d27c9ac741ab9e633af334b742e11d3e6349d70d3f65f4', 'TÉCNICO', '', 1, 3),
(22, 'TESTE', 'TESTE', '14474d3e747092839abf2dcf30e6d06b47338a61c0ce81723e88a8185927bcd834035357d2e35e2944d27c9ac741ab9e633af334b742e11d3e6349d70d3f65f4', 'ADMINISTRADOR', 'TESTE', 0, 8),
(23, 'KATIA ODO', 'cultura', '14474d3e747092839abf2dcf30e6d06b47338a61c0ce81723e88a8185927bcd834035357d2e35e2944d27c9ac741ab9e633af334b742e11d3e6349d70d3f65f4', 'OPERADOR', 'casadacultura@capivari.sp.gov.br', 1, 8),
(24, 'TATIANA CONCEICAO', 'tatiana.conceicao', '14474d3e747092839abf2dcf30e6d06b47338a61c0ce81723e88a8185927bcd834035357d2e35e2944d27c9ac741ab9e633af334b742e11d3e6349d70d3f65f4', 'OPERADOR', 'cras.conviver@capivari.sp.gov.br', 1, 8),
(25, 'ARTHUR', 'arthur.obras', '14474d3e747092839abf2dcf30e6d06b47338a61c0ce81723e88a8185927bcd834035357d2e35e2944d27c9ac741ab9e633af334b742e11d3e6349d70d3f65f4', 'OPERADOR', 'obras1@capivari.sp.gov.br', 1, 8);

--
-- Índices de tabelas apagadas
--

--
-- Índices de tabela `tb_departamento`
--
ALTER TABLE `tb_departamento`
  ADD PRIMARY KEY (`id_departamento`);

--
-- Índices de tabela `tb_historico`
--
ALTER TABLE `tb_historico`
  ADD KEY `fk_rootHistorico` (`nr_root`),
  ADD KEY `fk_historicoUser` (`id_usuario`);

--
-- Índices de tabela `tb_historicousuario`
--
ALTER TABLE `tb_historicousuario`
  ADD PRIMARY KEY (`id_usuario`,`id_usuarioAlterado`),
  ADD KEY `FK_usuario_desativado` (`id_usuarioAlterado`);

--
-- Índices de tabela `tb_historico_atendimento`
--
ALTER TABLE `tb_historico_atendimento`
  ADD PRIMARY KEY (`id_atendimento`),
  ADD KEY `FK_Departamento` (`id_departamento`),
  ADD KEY `FK_User` (`id_user`);

--
-- Índices de tabela `tb_root`
--
ALTER TABLE `tb_ocorrencia`
  ADD PRIMARY KEY (`nr_ocorrencia`),
  ADD KEY `FK_Userocorrencia` (`id_usuario`),
  ADD KEY `FK_Deptocorrencia` (`id_departamento`);

--
-- Índices de tabela `tb_procedimento`
--
ALTER TABLE `tb_procedimento`
  ADD KEY `fk_procedimentoroot` (`nr_ocorrencia`);

--
-- Índices de tabela `tb_responsaveis`
--
ALTER TABLE `tb_responsaveis`
  ADD PRIMARY KEY (`id_usuario`,`id_departamento`),
  ADD KEY `FK_departamentoResp_usuario` (`id_departamento`);

--
-- Índices de tabela `tb_usuario`
--
ALTER TABLE `tb_usuario`
  ADD PRIMARY KEY (`id_usuario`),
  ADD KEY `FK_DeptUser` (`id_departamento`);

--
-- AUTO_INCREMENT de tabelas apagadas
--

--
-- AUTO_INCREMENT de tabela `tb_departamento`
--
ALTER TABLE `tb_departamento`
  MODIFY `id_departamento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de tabela `tb_historico_atendimento`
--
ALTER TABLE `tb_historico_atendimento`
  MODIFY `id_atendimento` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `tb_root`
--
ALTER TABLE `tb_ocorrencia`
  MODIFY `nr_ocorrencia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=128;

--
-- AUTO_INCREMENT de tabela `tb_usuario`
--
ALTER TABLE `tb_usuario`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Restrições para dumps de tabelas
--

--
-- Restrições para tabelas `tb_historico`
--
ALTER TABLE `tb_historico`
  ADD CONSTRAINT `fk_ocorrenciaHistorico` FOREIGN KEY (`nr_ocorrencia`) REFERENCES `tb_ocorrencia` (`nr_ocorrencia`),
  ADD CONSTRAINT `historicoUser` FOREIGN KEY (`id_usuario`) REFERENCES `tb_usuario` (`id_usuario`);

--
-- Restrições para tabelas `tb_historicousuario`
--
ALTER TABLE `tb_historicousuario`
  ADD CONSTRAINT `FK_usuario_desativado` FOREIGN KEY (`id_usuarioAlterado`) REFERENCES `tb_usuario` (`id_usuario`),
  ADD CONSTRAINT `FK_usuario_historico` FOREIGN KEY (`id_usuario`) REFERENCES `tb_usuario` (`id_usuario`);

--
-- Restrições para tabelas `tb_historico_atendimento`
--
ALTER TABLE `tb_historico_atendimento`
  ADD CONSTRAINT `FK_Departamento` FOREIGN KEY (`id_departamento`) REFERENCES `tb_departamento` (`id_departamento`),
  ADD CONSTRAINT `FK_User` FOREIGN KEY (`id_user`) REFERENCES `tb_usuario` (`id_usuario`);

--
-- Restrições para tabelas `tb_root`
--
ALTER TABLE `tb_ocorrencia`
  ADD CONSTRAINT `FK_Deptocorrencia` FOREIGN KEY (`id_departamento`) REFERENCES `tb_departamento` (`id_departamento`),
  ADD CONSTRAINT `FK_Userocorrencia` FOREIGN KEY (`id_usuario`) REFERENCES `tb_usuario` (`id_usuario`);

--
-- Restrições para tabelas `tb_procedimento`
--
ALTER TABLE `tb_procedimento`
  ADD CONSTRAINT `fk_procedimentoroot` FOREIGN KEY (`nr_ocorrencia`) REFERENCES `tb_ocorrencia` (`nr_ocorrencia`);

--
-- Restrições para tabelas `tb_responsaveis`
--
ALTER TABLE `tb_responsaveis`
  ADD CONSTRAINT `FK_departamentoResp_usuario` FOREIGN KEY (`id_departamento`) REFERENCES `tb_departamento` (`id_departamento`),
  ADD CONSTRAINT `FK_usuario_departamentoResp` FOREIGN KEY (`id_usuario`) REFERENCES `tb_usuario` (`id_usuario`);

--
-- Restrições para tabelas `tb_usuario`
--
ALTER TABLE `tb_usuario`
  ADD CONSTRAINT `FK_DeptUser` FOREIGN KEY (`id_departamento`) REFERENCES `tb_departamento` (`id_departamento`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
