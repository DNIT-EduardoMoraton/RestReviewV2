filtrarObjetos("todos");

function filtrarObjetos(c) {
    var x, i;
    x = document.getElementsByClassName("w3-third w3-container w3-margin-bottom");
    if (c == "todos") c = "";
    for (i = 0; i < x.length; i++) {
        eliminarClase(x[i], "show");
        if (x[i].className.indexOf(c) > -1) anyadirClase(x[i], "show");
    }
}

function anyadirClase(elemento, nombre) {
    var i, arr1, arr2;
    arr1 = elemento.className.split("_");
    arr2 = nombre.split("_");
    for (i = 0; i < arr2.length; i++) {
        while (arr1.indexOf(arr2[i]) > -1) {
            arr1.splice(arr1.indexOf(arr2[i]), 1);
        }
    }
    elemento.className = arr1.join("_");
}

function eliminarClase(elemento, nombre) {
    var i, arr1, arr2;
    arr1 = elemento.className.split("_");
    arr2 = nombre.split("_");
    for (i = 0; i < arr2.length; i++) {
        while (arr1.indexOf(arr2[i]) > -1) {
            arr1.splice(arr1.indexOf(arr2[i]), 1);
        }
    }
    elemento.className = arr1.join("_");
}