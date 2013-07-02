# -*- coding: utf-8 -*-
class InitExample
  def initialize (greeter = nil)
    @greeter = greeter unless greeter.nil?
    @greeter = English.new() if greeter.nil?
  end

  def greeting
    @greeter.hello
  end

end

class Español
  def hello
    'Beunos dias'
  end
end

class English
  def hello
    'Howdy'
  end
end

puts "Default: #{InitExample.new().greeting}"
puts "Español: #{InitExample.new(Español.new).greeting}"