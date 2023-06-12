// token
var token;
var getall;
document.getElementById("botao-token").addEventListener("click", function(){
    let valor = document.getElementById("input-token").value;
    token = valor;
    console.log(token);
    document.querySelector(".resultados").style.display = "block";
    document.querySelector(".pesquisas").style.display = "block";
    document.querySelector(".intro").style.display = "none";
});

// getall
document.getElementById("botao-pega-tudo-pesquisa").addEventListener("click", function(){
    fetch('http://localhost:5293/api/surveys', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + token,
        },
    }).then(response => getall = response);
    console.log(getall);
});
