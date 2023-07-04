function printMatrixWithSpecificSize(size){
    let matrix = [];
    for(let i = 0; i < size; i++){
        let currString = `${size} `.repeat(size);
        matrix.push([currString])
    }
    console.log(matrix.join('\n'));
}
printMatrixWithSpecificSize(3);