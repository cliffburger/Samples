gem 'rubyzip'
require 'zip/zip'
require 'zip/zipfilesystem'
require 'albacore'

def compress(path, archive)
    puts path
    Zip::ZipFile.open(archive, 'w') do |zipfile|
    Dir["#{path}/**/**"].reject{|f|f==archive}.each do |file|
      zipfile.add(file.sub(path+'/',''),file)
    end
  end
end

def extract(archive, targetpath)
    
    Zip::ZipFile.open(archive, 'w') do |zipfile|
    Dir["#{path}/**/**"].reject{|f|f==archive}.each do |file|
      zipfile.add(file.sub(path+'/',''),file)
    end
  end
end

def get_package_output_archive
    return File.join(Dir.pwd, "zipped.zip")
end

archive = get_package_output_archive()
compress('output', archive)
compress('anotherfolder', archive)