function storeAddresses(addresses){
    let addressBook = addresses.reduce((acc, curr) => {
        const [name, address] = curr.split(':');
        acc[name] = address;

        return acc;
    }, {});

    let sortable = [];
    for(const name in addressBook){
        sortable.push([name, addressBook[name]]);
    }

    sortable.sort();
    sortable.forEach(([name, address]) =>{
        console.log(`${name} -> ${address}`);
    });
}
storeAddresses(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);
storeAddresses(['Bob:Huxley Rd',
'John:Milwaukee Crossing',
'Peter:Fordem Ave',
'Bob:Redwing Ave',
'George:Mesta Crossing',
'Ted:Gateway Way',
'Bill:Gateway Way',
'John:Grover Rd',
'Peter:Huxley Rd',
'Jeff:Gateway Way',
'Jeff:Huxley Rd']
)