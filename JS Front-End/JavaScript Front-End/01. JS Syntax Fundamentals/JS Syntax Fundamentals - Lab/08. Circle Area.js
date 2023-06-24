function calculateCircleArea(input){
    let type = typeof(input);
    if(type === 'number'){
        let area = input * input * Math.PI;
        console.log(area.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${type}.`);
    }
}
calculateCircleArea(5); //75.54
calculateCircleArea('name') //error message