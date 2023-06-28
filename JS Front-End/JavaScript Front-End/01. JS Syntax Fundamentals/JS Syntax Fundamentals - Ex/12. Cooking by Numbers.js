function cookWithNumber(...input){
    let num = Number(input.shift());
    input.forEach(elelemt => {
        switch(elelemt){
            case 'chop': num /= 2; break;
            case 'dice': num = Math.sqrt(num); break;
            case 'spice': num++; break;
            case 'bake': num *= 3; break;
            case 'fillet': num *= 0.80; break;
        }
        console.log(num.toString().includes('.') ? num.toFixed(1) : num);
    });
}
cookWithNumber('32', 'chop', 'chop', 'chop', 'chop', 'chop'); //16 | 8 | 4 | 2 | 1
cookWithNumber('9', 'dice', 'spice', 'chop', 'bake', 'fillet'); //3 | 4 | 2 | 6 | 4.8