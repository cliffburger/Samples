=begin
rake -f params.rb
rake -f params.rb -P 
rake -f params.rb task1
rake -f params.rb task1['Anaconda','Big Boy','California']
=end

task :default do
    puts 'Expirements in parameter passing'
end

task :task1 => [:init, :task2]
task :task1, [:a,:b,:c] do |t, args|
    args.with_defaults(:a=>"Aardvark",:b=>"Bananna",:c=>"Cow")
    puts 'Task 1!'
    Rake::Task["task3"].invoke(args.a, args.c)
end

task :task2, [:b,:c] do |t, args|
   puts 'Task 2!'
   puts "Doing b... #{args.b} "
   puts "Doing c... #{args.c} "
end

task :task3, [:b,:c] do |t, args|
   puts 'Task 3!'
   puts "Considering A ... #{args.b} "
   puts "Considering c... #{args.c} "
end

task :init, [:a,:b] do |t, args|
    puts "Initializing... #{args.a} "
    puts "Initializing... #{args.b} "
end

