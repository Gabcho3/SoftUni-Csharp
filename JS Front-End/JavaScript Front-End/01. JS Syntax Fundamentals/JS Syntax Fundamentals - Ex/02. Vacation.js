function calculateVacationPrice(people, groupType, day){
    let totalPrice = 0;

    switch(groupType){
        case 'Students':
            switch(day){
                case 'Friday': totalPrice = 8.45; break;
                case 'Saturday': totalPrice = 9.80; break;
                case 'Sunday': totalPrice = 10.46; break;
            }
            totalPrice *= people;
            totalPrice *= people >= 30 ?  0.85 : 1;
        break;

        case 'Business':
            let priceForPerson = 0;
            switch(day){
                case 'Friday': priceForPerson = 10.90; break;
                case 'Saturday': priceForPerson = 15.60; break;
                case 'Sunday': priceForPerson = 16.00; break;
            }
            totalPrice = priceForPerson * people;
            totalPrice -= people >= 100 ? priceForPerson * 10 : 0;
        break;

        case 'Regular':
            switch(day){
                case 'Friday': totalPrice = 15.00; break;
                case 'Saturday': totalPrice = 20.00; break;
                case 'Sunday': totalPrice = 22.50; break;
            }
            totalPrice *= people;
            totalPrice *= people >= 10 && people <= 20 ? 0.95 : 1;
        break;
    }
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}
calculateVacationPrice(30,"Students","Sunday"); //Total price: 266.73
calculateVacationPrice(100, "Business", 'Friday'); //Total price: 981.00
calculateVacationPrice(40, "Regular", "Saturday"); //Total price: 800.00