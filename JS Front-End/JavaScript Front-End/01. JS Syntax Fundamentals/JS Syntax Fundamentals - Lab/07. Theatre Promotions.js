function promotions(day, age){
    if(age < 0 || age > 122){
        console.log("Error!");
        return;
    }

    let price;

    switch(day){
        case 'Weekday':
            if(age >= 0 && age <= 18 || (age > 64 && age <= 122)){
                price = 12;
            }
            else{
                price = 18;
            }
        break;

        case 'Weekend':
            if(age >= 0 && age <= 18 || (age > 64 && age <= 122)){
                price = 15;
            }
            else{
                price = 20;
            }
        break;

        case 'Holiday':
            if(age >= 0 && age <= 18){
                price = 5;
            }
            else if(age > 18 && age <= 64){
                price = 12;
            }
            else{
                price = 10;
            }
        break;
    }
    console.log(`${price}$`);
}
promotions('Weekday', 42); //18$
promotions('Holiday', -12); //Error!
promotions('Holiday', 15); //5$