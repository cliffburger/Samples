filepath = 'c:/temp/hosts.txt'
text = File.read(filepath)
puts text.length
line = '192.0.0.1 wwwroot.hq.daptiv.com'
if(text.gsub!(/^.*wwwroot\.hq\.daptiv\.com.*$/, line) == nil)
  puts "not found in file"
  text += line
end

File.open(filepath, "w") {|file| file.puts text}
puts text.length