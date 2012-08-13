# Hello World
puts "This will be cool!"


def convert_base(number_string,base1,base2)
	puts "Convert #{number_string} from #{base1} to #{base2}"
	check_input(number_string,base1,base2)	
	
	return number_string if base1==base2
	
<=

Algorithms:
==============
Convert to base 2?
===============
Drop values and roll left
	
The 0th place (rightmost) of the value to be converted,
	drop values in the first number of the target until
		the target base is exceeded.
	Place remainder in place 0.
		Iterate until no values exceed the target base.
For positions 2 and up

How do the places relate to each each other? Where do we start dropping values from the input?
	Same (return input)
	The xth place is the base to the power of the position.
	e.g 10 in base 10 = 10^1
		100 in base 4 = 4^2
	
	Converting base 3 to 5
		121(3)
		2 + 2*3^1 + 1*3^2
		1st 1(5)
		2nd 1(5) + (2*3) 
			1 in place 1, remainder 4
		
	Converting base 7 to 4
		563(7)
		3 + 6*7**1 + 5*7**2
		1st 3(4)
		2nd 42(10) 60(7)
			??? sleep on this
=>
end

def check_input(number_string,base1,base2)
	throw "base1" if base1 < 2
	throw "base2" if base2 < 2
	throw "The number string should be an array" if !number_string.kind_of?(Array)
	baditems = number_string.select{|item| item >= base1}
	throw "A value was larger than the base it came from" if baditems != nil and baditems.size > 0
end

result = convert_base([3,4],10,10)
puts result
