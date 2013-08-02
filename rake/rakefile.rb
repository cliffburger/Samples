=begin
Purpose: Explore importing other rakefiles

rake --version
rake -T
rake
rake fail
=end
import 'support/tasks.rb'

desc "Default task"
task :default do |t|
    Dir.glob('./support/**/*.rake').each { |r| puts "<boom> #{r} </boom>" }
end

desc "Fail task!"
task :fail do |t|
	raise "fail!"
end