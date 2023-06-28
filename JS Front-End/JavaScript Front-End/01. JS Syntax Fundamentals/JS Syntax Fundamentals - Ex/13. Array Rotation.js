function rotateArreay(array, rotations){
    for(let rotation = 1; rotation <= rotations; rotation++){
        array.push(array.shift());
    }
    console.log(array.join(' '));
}
rotateArreay([51, 47, 32, 61, 21], 2); //32 61 21 51 47
rotateArreay([32, 21, 61, 1], 4); //32 21 61 1
rotateArreay([2, 4, 15, 31], 5); //4 15 31 2