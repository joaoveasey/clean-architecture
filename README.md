# Clean Architecture
### Este repositório apresenta um exemplo de aplicação utilizando Clean Architecture, seguindo os princípios de independência e modularidade para garantir que o projeto seja testável, escalável e fácil de manter.

## 🎯 Características da Clean Architecture
* **Independente de frameworks**: O sistema não é acoplado a frameworks específicos, permitindo que eles sejam substituídos sem impacto nas regras de negócio.
###
* **Testável**: As regras de negócio podem ser facilmente testadas em isolamento.
###
* **Independente da camada de apresentação (UI)**: A lógica de negócios é separada da interface de usuário, facilitando a troca de interfaces.
###
* **Independente do banco de dados**: A arquitetura não depende de uma base de dados específica, permitindo a troca de tecnologias de armazenamento sem impacto nas camadas internas.
###
* **Independente de fatores externos**: Componentes externos como bibliotecas, APIs ou frameworks não impactam as regras de negócio.
###

## 🧩 Camadas da Arquitetura
### 1. Regras de Negócio da Empresa (Camada mais interna)
* **Entidades**: Contém os objetos de domínio e as regras de negócio principais, bem como contratos de serviço.
### 2. Regras de Negócio da Aplicação (Segunda camada)
* **Casos de Uso**: Representam ações específicas dentro do sistema, orquestrando o fluxo de dados e aplicando as regras de negócio.
### 3. Adaptadores de Interface (Terceira camada)
* **Comunicação**: Responsável por realizar a comunicação entre as entidades e os componentes externos da aplicação.
### 4. Frameworks e Drivers (Quarta camada)
* **Recursos Externos**: Contém frameworks, drivers, banco de dados e outros recursos externos necessários para o funcionamento do sistema.

###
 
### 🔄 Regra de Dependência
* **Isolamento**: As camadas internas não devem ter qualquer dependência das camadas externas, nem mesmo indiretas, como nomes de variáveis e funções.

###
  
## 🏗️ Estrutura do Projeto
A solução é composta por 5 projetos distintos:

### 📂 Catalogo.Domain 
* Função: Modelos de domínio, interfaces e regras de negócio.
* Tipo de Projeto: Class Library (.NET 8)
  
###

### 📂 Catalogo.Application
* Função: Regras da aplicação, serviços, mapeamentos e DTOs.
* Tipo de Projeto: Class Library (.NET 8)

###

### 📂 Catalogo.Infrastructure
* Função: Lógica de acesso aos dados, contexto, configurações e ORM.
* Tipo de Projeto: Class Library (.NET 8)

###

### 📂 Catalogo.CrossCutting
* Função: Implementa preocupações transversais, como IoC, registro de serviços e DI.
* Tipo de Projeto: Class Library (.NET 8)

###

### 📂 Catalogo.API
* Função: Controladores, endpoints e filtros.
* Tipo de Projeto: ASP.NET Web API

###

## 🔗 Dependências entre os Projetos
* Domain: Não contém nenhuma dependência dos outros projetos, pois representa o núcleo da lógica de negócios da aplicação.

* Application: Faz referência ao projeto Domain, utilizando conceitos e tipos definidos nele.

* Infrastructure: Faz referência ao projeto Domain, interagindo com os objetos de domínio para acessar dados.

* CrossCutting: Faz referência aos projetos Domain, Application e Infrastructure, permitindo que interaja com várias partes da aplicação para implementar as funcionalidades transversais.

* API: Faz referência ao projeto CrossCutting, para acessar as funcionalidades transversais e disponibilizá-las através dos endpoints.

###

![image](https://github.com/user-attachments/assets/efc6faa9-6dac-4f88-aa61-08dbffdbe4d0)