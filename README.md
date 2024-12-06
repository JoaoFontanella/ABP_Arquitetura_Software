# Plataforma de Cursos Online
Microsserviços: <br> Alunos <br> Cursos <br> Matrículas <br>


Fluxo: <br>
Ao consultar um curso, exibir a lista de alunos matriculados.
Validar o status do curso ao registrar uma nova matrícula.
Atualizar o histórico do usuário ao completar um curso.

Requisitos Funcionais: <br>

Cadastro de Usuários

Permitir que alunos e instrutores se registrem com informações básicas (nome, e-mail).
Disponibilizar endpoint para consulta de detalhes do usuário.
Gestão de Cursos

Permitir que instrutores cadastrem cursos com título, descrição.
Disponibilizar endpoint para listar e consultar cursos específicos.
Gerenciamento de Matrículas

Registrar a matrícula de um aluno em um curso.
Validar dados de alunos e cursos antes de concluir a matrícula.
Disponibilizar consulta ao histórico de matrículas do aluno.


Requisitos Não Funcionais: <br>

Desempenho

Garantir que o tempo de resposta dos endpoints não ultrapasse 500ms.
Escalabilidade

Permitir que cada microsserviço seja escalado de forma independente.
Segurança

Garantir comunicação segura entre microsserviços.
Disponibilidade

Assegurar que o sistema tenha uptime mínimo de 99,9%.
Documentação

Utilizar Swagger para descrever detalhadamente os endpoints disponíveis.
Manutenção

Modularidade para facilitar atualizações e correção de bugs em serviços individuais.
Persistência de Dados

Utilizar SQLite com possibilidade de migração futura para bancos de dados mais robustos.
Confiabilidade

Implementar logs e monitoramento para rastrear falhas e eventos no sistema.
