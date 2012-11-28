=begin
Purpose: Investigate methods to ensure execution of tasks after a test suite that may fail.

rake -T -f ensure.rb 
rake -f ensure.rb  execute_succeed --trace
rake -f ensure.rb  execute_fail --trace

rake -f ensure.rb  execute_ensure --trace
rake -f ensure.rb  execute_ensure_tasks --trace
rake -f ensure.rb  execute_ensure['execute_fail'] --trace
rake -f ensure.rb  cleanup_website --trace

md support
=end
require 'albacore'

task :execute_ensure, [:ensured_task] => [:initialize_directories, :cleanup_website] do |t, args|
	args.with_defaults(:ensured_task => "execute_succeed")
	begin
		Rake::Task[args.ensured_task].invoke(args.test_categories_include, args.test_categories_exclude, args.more_options)
	ensure
		Rake::Task["test_results"].invoke()
		cleanup '"From method"'
	end
end

task :execute_ensure_tasks, [:ensured_task] => [:initialize_directories, :cleanup_website] do |t, args|
	args.with_defaults(:ensured_task => "execute_succeed")
	begin
		Rake::Task[args.ensured_task].invoke(args.test_categories_include, args.test_categories_exclude, args.more_options)
	ensure
		Rake::Task["test_results"].invoke()
		Rake::Task["cleanup_website"].invoke()
	end
end

desc "Executes commandecho to return 0"
task :execute_succeed do |t, args|
	puts "Hello world!"
end

desc "Executes commandecho to return 0"
task :execute_fail do |t, args|
	puts "Hello world!"
	throw "Oh no!"
end

desc "Cleanup processes left behind by tests that use the website"
task :cleanup_website do |t, args|
	puts "Cleaning up!"
	cleanup '"From task"'
end

desc "Create the artifacts directories used for test results and other artifacts."
task :initialize_directories do |t, args|
	puts "Initializing"
end

desc "Publishing test results"
task :test_results do |t, args|
	puts "Publishing test results!"
end

def cleanup(options)
	puts "Cleaning up!"
	cmd=File.join(Dir.pwd,"commandecho.rb")
	output = `ruby #{cmd} #{options}`
	puts output
end