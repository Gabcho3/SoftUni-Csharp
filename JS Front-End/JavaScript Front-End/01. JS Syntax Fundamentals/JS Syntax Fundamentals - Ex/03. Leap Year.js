function isLeapYear(year){
    let output = '';
    if((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0){
        output = 'yes';
    } else{
        output = 'no';
    }
    console.log(output);
}
isLeapYear(1900); //no
isLeapYear(2003); //no
isLeapYear(4); //yes