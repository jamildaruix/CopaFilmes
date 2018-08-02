# CopaFilmes
    * Copa do Mundo Filmes 
    * Desenvolvido em duas camadas sendo a parte da aplicação e web utilizando framework 4.5
    * Foi colocado teste unitários para fazer o teste da camada de aplicação
    * Boostrap utilizado é a versão 4.0
    * Na aplicação web existe um arquivo css no caminho \Content\site-header.css
    * Na aplicação web existe um arquivo js no caminho \Scripts\Movie\movie.js
    * Configuração do AutoMapper está no caminho \AutoMapper
    * No projeto web foi criado duas partial cshtml para elaboração do header das view
    * O teste possuí DI e configurado no global.ascx
    * Na camada da aplicação existe uma classe genérica para consumir API em questão
    * Existem duas configurações no web.config sendo elas ApiCup e TimeoutPolicySeconds

# CopaFilmes.Application
    * Usado o Newtonsoft.Json na aplicação Install-Package Newtonsoft.Json -Version 11.0.2
    * Usado o Polly para gerenciar exceções e executar a tarefa novamente Install-Package Polly
    * Usado o Simple Injector na aplicação Install-Package SimpleInjector    
    * Usado o CommonServiceLocation Install-Package CommonServiceLocation -Version 1.0.0   

# CopaFilmes.Test
    * Usado o Simple Injector na aplicação Install-Package SimpleInjector
    * Usado o Simple Injector mvc na aplicação Install-Package SimpleInjector.Integration.Web.Mvc -Version 4.3.0
    * Usado o CommonServiceLocation Install-Package CommonServiceLocation -Version 1.0.0	

# CopaFilmes.Web
    * Usado o AutoMapper na aplicação Install-Package AutoMapper -Version 7.0.1
    * Usado o Newtonsoft.Json na aplicação Install-Package Newtonsoft.Json -Version 11.0.2
    * Usado o Simple Injector na aplicação Install-Package SimpleInjector
    * Usado o Simple Injector mvc na aplicação Install-Package SimpleInjector.Integration.Web.Mvc -Version 4.3.0
    * Usado o CommonServiceLocation Install-Package CommonServiceLocation -Version 1.0.0	