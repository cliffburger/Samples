=begin
rake -f ordering.rb
rake -f ordering.rb -P
rake -f ordering.rb devrun
rake -f ordering.rb dev2
=end

task :default do
    puts 'Tasks you can run: dev, stage, prod'
end

task :devrun => [:init]
task :devrun do
    puts 'Dev stuff'
    Rake::Task["dirtytask"].invoke()    
    Rake::Task["cleanup"].invoke()
end

task :dev2 => [:init] do
    puts 'Dev stuff'
    Rake::Task["dirtytask"].invoke()    
    Rake::Task["cleanup"].invoke()
end

task :dirtytask

task :dirtytask do
    puts 'Do some dirty stuff'
end

task :init do
    puts 'Initializing...'    
end

task :cleanup do
    puts 'Clean'
end