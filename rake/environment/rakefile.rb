=begin
Purpose: Demonstrate inability to call java from ruby in TC 7.1

rake 
rake java_fully_qualified
=end

desc "This task executes java -version, without fully qualifying. Worked in TC 7.0"
task :default do
	puts "\n\n JAVA TEST with java -version should show at the top of this rake file. "
	`java -version`
end

desc "This task executes java -version, fully qualify the java path. This is the workaround in TC 7.1"
task :java_fully_qualified  do
	puts "\n\n JAVA FULLY QUALIFIED  java -version should show at the top of this rake file. "
	java_exe = File.join(ENV["JAVA_HOME"],"bin","java.exe")
	`\"#{java_exe}\" -version`
end