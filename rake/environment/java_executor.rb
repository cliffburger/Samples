class JavaExecutor
	@java_exec_location
	
		# @return [String] The location of java, based on the JAVA_HOME environment variable
		def java_exe_location
			return @java_exec_location unless @java_exec_location == nil
	
			throw ("The JAVA_HOME environment variable is not defined!") if ENV["JAVA_HOME"] == nil
			java_exe = File.join(ENV["JAVA_HOME"],"bin","java.exe")
			throw ("Java.exe not found at #{java_exe}") unless File.exist? (java_exe)
			@java_exec_location = java_exe
	
			@java_exec_location
		end
	
		# @return [String] Returns output from the execution
		def execute_jar(jar_file, arguments)
			command = "\"#{java_exe_location}\" -jar \"#{jar_file}\" #{arguments}"
			`#{command}`
		end

		def exec_version_full_path
			command = "\"#{java_exe_location}\" -version"
			`#{command}`
		end

		def exec_version
			`java -version`
		end

		def exec_version_system
			system("java -version")
		end
end

puts "PATH VALUES"
puts ENV["PATH"].gsub(";","\n")

executor = JavaExecutor.new()
puts "\n\nWith full path ... #{executor.java_exe_location}"

executor.exec_version_full_path

puts "\n\nWithout full path"

executor.exec_version

puts "\n\nUsing system, without full path"
# Never gets here, but fails with same error
executor.exec_version_system




