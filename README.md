# GlobalSolution_EnergyFall

Sistema desenvolvido para simular o comportamento de um servidor durante uma **queda de energia**, com foco em:

- Validação de login e simulação de perda de dados
- Registro de logs do sistema e diagnósticos pós-falha
- Interface via console (CLI) com menu CRUD fictício
- Análise de integridade de dados após falhas

---

## Finalidade

Este projeto tem como objetivo **simular uma falha crítica no sistema (queda de energia)** logo após o login de um usuário. Ele avalia o impacto da falha sobre os dados do sistema e demonstra boas práticas como:

- Logging de eventos
- Diagnóstico pós-falha
- Validações básicas de segurança
- Simulação de banco de dados em memória

---

## 🚀 Instruções de Execução

1. **Pré-requisitos**:
   - [.NET 6 SDK ou superior](https://dotnet.microsoft.com/download)
   - Visual Studio ou terminal com `dotnet` instalado

2. **Clone o repositório**:
   ```bash
   git clone https://github.com/seuusuario/GlobalSolution_EnergyFall.git
   cd GlobalSolution_EnergyFall
