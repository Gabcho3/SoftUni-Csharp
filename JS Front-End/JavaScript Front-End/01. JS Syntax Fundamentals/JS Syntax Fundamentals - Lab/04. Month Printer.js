function printMonth(num){
    const months = ['January', 'Fabruary', 'March', 'April', 'May', 'June', 'July', 'August', 
    'September', 'October', 'November', 'December'];
    
    let index = num - 1;
    console.log(num > 12 ? 'Error!' : months[index]);
}