function printSumOfFirstAndLastArrayEllements(array){
    let firstElement = array[0];
    let lastElement= array[array.length - 1];
    console.log(firstElement + lastElement);
}
printSumOfFirstAndLastArrayEllements([20, 30, 40]) //60
printSumOfFirstAndLastArrayEllements([10, 17, 22, 33]); //43
printSumOfFirstAndLastArrayEllements([11, 58, 69]); //80