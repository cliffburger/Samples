/* Object property access example */
var nameProperty = 'name',
    kid1 = {
    name: 'Tenzing',
    birthdate: new Date(2004,6,22)
};

console.log(kid1['name']);
console.log(kid1.name);
console.log(kid1[nameProperty]);
console.log(kid1);


