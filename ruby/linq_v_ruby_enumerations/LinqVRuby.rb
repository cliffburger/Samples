require 'thor'

# From a list, filter
class LinqVRuby < Thor

  desc "demo_select", "demonstrates basic select (filters)"
  def demo_select
    puts (1..10).select { |i| i < 4 }
    puts (1..10).find_all { |i| i % 4 == 0 }
  end

  desc "demo_split", "Port of the first example from LinqPad samples"
  def demo_split
    puts "The quick brown fox jumps over the lazy dog".split(/\s/)
  end

  def aggregate_files_by_extension(start_folder)
    # TODO:
  end
end

LinqVRuby.start(ARGV)