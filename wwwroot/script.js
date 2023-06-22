// token
var token;
var getall;
var getsingle;
document.getElementById("botao-token").addEventListener("click", function(){
    let valor = document.getElementById("input-token").value;
    token = valor;
    console.log(token);
    document.querySelector(".resultados").style.display = "block";
    document.querySelector(".pesquisas").style.display = "block";
    document.querySelector(".intro").style.display = "none";
});

var criapergunta = function(pergunta){
    let perguntadiv = document.createElement("div");
    perguntadiv.classList.add("pergunta");
    let titulo = document.createElement("h3");
    let titulonode = document.createTextNode(pergunta.title);
    titulo.appendChild(titulonode);
    let conteudopergunta = document.createElement("div");
    let conteudoperguntanode = document.createTextNode(pergunta.content);
    conteudopergunta.appendChild(conteudoperguntanode);
    perguntadiv.appendChild(titulo);
    perguntadiv.appendChild(conteudopergunta);
    return perguntadiv;
}

var criapesquisa = function(pesquisa){
    let pesquisadiv = document.createElement("div");
    let pesquisaid = "pesquisa-div-" + pesquisa.id;
    pesquisadiv.classList.add(pesquisaid);
    let titulo = document.createElement("h1");
    let titulonode = document.createTextNode(pesquisa.name);
    titulo.appendChild(titulonode);
    let intro = document.createElement("p");
    intro.classList.add("linha-bottom");
    let intronode = document.createTextNode(pesquisa.intro);
    intro.appendChild(intronode);
    pesquisadiv.appendChild(titulo);
    pesquisadiv.appendChild(intro);
    let resultados = document.querySelector(".resultados");
    resultados.appendChild(pesquisadiv);
    if(pesquisa.questionsId == null)
    {
        return;
    }
    pesquisa.questionsId.forEach(id => {
        let url = 'http://localhost:5293/api/questions/' + id;
        fetch(url, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + token,
        },
    })
    .then(data => data.json())
    .then(response => {
        let perguntadiv = criapergunta(response.data);
        console.log(perguntadiv);
        pesquisadiv.appendChild(perguntadiv);        
    });
    });
}

// getall
document.getElementById("botao-pega-tudo-pesquisa").addEventListener("click", async function(){
    let resultados = document.querySelector(".resultados");
    resultados.innerHTML = "";
    await fetch('http://localhost:5293/api/surveys', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + token,
        },
    })
    .then(data => data.json())
    .then(response => getall = response);
    console.log(getall);
    getall.data.forEach(pesquisa => {
        criapesquisa(pesquisa);
    });
});

// getsingle 
document.getElementById("botao-pega-id").addEventListener("click", async function(){
    let resultados = document.querySelector(".resultados");
    resultados.innerHTML = "";
    let id = document.querySelector("#pesquisa-input-id-pega").value;
    let url = 'http://localhost:5293/api/surveys/' + id;
    await fetch(url, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + token,
        },
    })
    .then(data => data.json())
    .then(response => getsingle = response);
    criapesquisa(getsingle.data);
});

// post
document.getElementById("botao-cria-pesquisa").addEventListener("click", async function(){
    let intro = document.querySelector("#pesquisa-input-intro").value;
    let nome = document.querySelector("#pesquisa-input-nome").value;
    let resultados = document.querySelector(".resultados");
    resultados.innerHTML = "";
    let id = document.querySelector("#pesquisa-input-id-pega").value;
    let url = 'http://localhost:5293/api/surveys/' + id;
    await fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + token,
        },
        body: JSON.stringify({"name": nome, "intro": intro}),
    })
    .then(data => data.json())
    .then(response => getsingle = response);
    criapesquisa(getsingle.data);
});

// xclui
document.getElementById("botao-exclui-id").addEventListener("click", async function(){
    let resultados = document.querySelector(".resultados");
    resultados.innerHTML = "";
    let id = document.querySelector("#pesquisa-input-id-excluir").value;
    let url = 'http://localhost:5293/api/surveys/' + id;
    await fetch(url, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json', 
          'Authorization': 'Bearer ' + token,
        },
    })
    .then(data => data.json())
    .then(response => getsingle = response);
    console.log("foi porraaaa");
});

// edit
document.getElementById("botao-edita-id").addEventListener("click", async function(){
    let intro = document.querySelector("#pesquisa-input-intro-editar").value;
    let nome = document.querySelector("#pesquisa-input-nome-editar").value;
    let resultados = document.querySelector(".resultados");
    resultados.innerHTML = "";
    let id = document.querySelector("#pesquisa-input-id-editar").value;
    let url = 'http://localhost:5293/api/surveys/'
    await fetch(url, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + token,
        },
        body: JSON.stringify({"id": id, "name": nome, "intro": intro}),
    })
    .then(data => data.json())
    .then(response => getsingle = response);
    criapesquisa(getsingle.data);
});