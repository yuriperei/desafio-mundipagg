# Desafio MundiPagg

## Visão Geral

O sistema tem como objetivo gerenciar sua coleção de livros/CDs/DVDs. É possível saber a localização do item e ter itens repetidos e em lugares diferentes. Além disso, é possível emprestar itens e saber com quem e qual o contato desta pessoa.

Em listagem, é possível ordenar os itens pelas diversas colunas existentes. Também deve ser possível filtrar pelo tipo do item, por livros disponíveis e emprestados, e por palavra-chave que busque simultaneamente por todos os campos.

  ### Tecnologias utilizadas
  
  * ASP.NET Core 1.0
  * Inversão de Controle (IoC)
  * Bootstrap
  * Angular 2
  * ElasticSearch
  * Typescript
  
## Conteúdo

### Geral

* [Requisitos](#requisitos)
* [Instalação](#instalação)
* [Utilização](#utilização)

### Serviço

* [Documentação API](#documentação-api)

## Requisitos

- Visual Studio 2017
- Elasticsearch 2.3.1 (É necessário ter a JVM [Java Virtual Machine])
- NodeJS 6 ou superior

## Instalação

### Elasticsearch

Estou disponibilizando para [download](https://s3.amazonaws.com/caelum-online-public/elasticsearch/downloads/elasticsearch-2.3.1.zip) a versão utilizada no projeto. A instalação do ElasticSearch é bem simples. Basta descompactar o arquivo compactado em qualquer pasta que você tenha acesso de escrita. 

Para iniciar o processo do ElasticSearch com as configurações padrão basta executar o comando elasticsearch para sua plataforma que está disponível dentro da pasta bin.

**Atenção:** A execução do ElasticSearch depende da [JVM](http://www.oracle.com/technetwork/pt/java/javase/downloads/jre8-downloads-2133155.html)  estar previamente instalada no seu ambiente. Tenha certeza que você tem a versão mais atual da JVM instalada e que o comando java está no path do seu ambiente. Note também que o ElasticSearch, por padrão, utiliza as portas 9200 e 9300.

### NodeJS

No momento da instalação do Visual Studio 2017, você pode instalar o pacote que contém o NodeJS. Mas, caso deseje instalar por fora, efetue o download no [site](https://nodejs.org/en/download/).

## Utilização

A interface do sistema utiliza Angular 2 com Bootstrap, que consome os serviços disponibilizados pelo aplicativo feito em ASP.NET Core utilizando a arquitetura Domain Driven Design (DDD).

1. Efetue o download do projeto ou utilize o git para clonar: `git clone https://github.com/yuriperei/desafio-mundipagg.git`

2. Execute o processo do Elasticsearch executando o comando elasticsearch para sua plataforma que está disponível dentro da pasta bin. Agora se você abrir um navegador e digitar: `http://localhost:9200` você irá vê-lo funcionando.

3. Abra duas instâncias do Visual Studio e abra a solution do projeto em cada uma dessas instâncias. Isso é necessário porque precisamos rodar a interface do sitema e os serviços. 

4. Abra uma das instâncias e clique com o botão direito do mouse sobre o projeto [DesafioMundiPagg.Presentation] dentro da pasta (1-Presentation) e defina-o como projeto de inicialização. Após isso, inicie o servidor IIS.

5. Abra a outra instância e lique com o botão direito do mouse sobre o projeto [DesafioMundiPagg.Service.WebApi] dentro da pasta (2-Service) e defina-o como projeto de inicialização. Após isso, inicie o servidor IIS.

6. Certifique que a instância do Service esteja rodando na porta: 49807. Caso esteja, pule para o passo [8]. Se *NÃO* estiver, olhe o passo [7]. 
    
7. Pause o IIS de [DesafioMundiPagg.Presentation]. Navegue até: `DesafioMundiPagg.Presentation >> ClientApp >> app >> services`. Agora, em cada service você verá uma variável url, então substitua a porta 49807 pela sua. Feito isso, inicie o servidor IIS.

8. Abra o navegador que está rodando a instância de Presentatione atualize. Pronto! Agora você está apto à utilizar o sistema.

## Documentação API

A documentação referente o serviço encontra-se nesse [link](https://github.com/yuriperei/desafio-mundipagg/blob/master/DOCAPI.apiry).
