function createListOfEmployees(input){
    const listOfEmployees = input.map(name => {
        const employee = {
            Name: name,
            "Personal Number": name.length,
        };
        return employee;
    })

    listOfEmployees.forEach(employee => {
        console.log(`Name: ${employee.Name} -- Personal Number: ${employee["Personal Number"]}`);
    });
}
createListOfEmployees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );