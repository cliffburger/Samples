=begin
This script echos command line input
commandecho.rb
=end
puts "This script will now write out the #{ARGV.count} argument(s) you provided."

ARGV.each do|a|
	puts "Argument: #{a}"
end

=begin
if(ARGV.count > 0 && ARGV[0].to_i != 0)
	Kernel::exit ARGV[0].to_i
end
=end
