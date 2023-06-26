function reverseArray(num, array){
    let newArray = [];
    for(let i = 0; i < num; i++){
        newArray[i] = array[i]
    }

    let output = '';
    for(let i = newArray.length - 1; i >= 0; i--){
        output += array[i] + ' ';
    }
    console.log(output);
}
reverseArray(3, [10, 20, 30, 40, 50]); //30 20 10
reverseArray(4, [-1, 20, 99, 5]); //5 99 20 -1
reverseArray(2, [66, 43, 75, 89, 47]); //43 66