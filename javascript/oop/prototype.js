// Prototype example

function Person (lastName, firstName) {
	this.lastName = lastName;
	this.firstName = firstName;
	this.getLastName = function () {
		return this.lastName;
	}
}

Person.prototype.getFirstName = function () {
	return this.firstName;
}

test("getLastName", function() {
	var person = new Person("Burger");
	ok(person.getLastName() == "Burger");
});

test("getFirstName", function() {
	var person = new Person("Burger","Tenzing");
	ok(person.getFirstName() == "Tenzing");
});

test("instances", function() {
	var tenzing = new Person("Burger", "Tenzing");
	var kepler = new Person("Burger", "Kepler");
	
	ok(tenzing.getFirstName() == "Tenzing");
	ok(kepler.getFirstName() == "Kepler");
});